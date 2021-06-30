using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TIPP.Server.Domain;
using TIPP.Server.Repositories;
using TIPP.Shared;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TIPP.Server.Controllers
{
    [Route("api/milestone")]
    [ApiController]
    public class MilestoneController : ControllerBase
    {
        private readonly IMilestoneRepository repository;

        public MilestoneController(tipp_DBContext context)
        {
            repository =  new MilestoneRepository(context);
        }



        // GET: api/<milestone>
        [HttpGet]
        public string GetAll()
        {
            return JsonConvert.SerializeObject(repository.GetMilestones());
        }

        [HttpGet("getbyactivityid/{userid}/{id}")]
        public string GetByActivityId(int userid, int id)
        {
            MilestoneDTO dto = new MilestoneDTO();
            dto.ActivityId = id;
            dto.UserId = userid;
            string result = JsonConvert.SerializeObject(repository.GetMilestonesByActivityId(dto));
            Console.WriteLine(result);
            return result;
        }

        [HttpGet("getcolleaguemilestones/{userid}/{projectid}")]
        public string GetColleagueMilestonesByProjectID(int userid, int projectid)
        {
            ProjectDTO dto = new ProjectDTO();
            dto.Id = projectid;
            string result = JsonConvert.SerializeObject(repository.GetColleagueMilestonesByProjectID(userid, dto));
            return result;
        }

        // GET api/<milestone>/5
        [HttpGet("{id}")]
        public string Get([FromBody]string value)
        {
            try
            {
                MilestoneDTO dto = JsonConvert.DeserializeObject<MilestoneDTO>(value);
                return JsonConvert.SerializeObject(repository.ReadMilestone(dto));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return null;
            }
            
        }

        // POST api/<milestone>
        [HttpPost]
        public ObjectResult Post([FromBody] string value)
        {
            try
            {
                MilestoneDTO dto = JsonConvert.DeserializeObject<MilestoneDTO>(value);
                if(repository.CreateMilestone(dto)!=null)
                {
                    return new AcceptedResult("Milestone", dto.Name);
                }
                else
                {
                    return new BadRequestObjectResult(false);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return new BadRequestObjectResult(ex);
            }
        }

        // PUT api/<milestone>/5
        [HttpPut("{id}")]
        public ObjectResult Put(int id, [FromBody] string value)
        {
            try
            {
                MilestoneDTO dto = JsonConvert.DeserializeObject<MilestoneDTO>(value);
                if(repository.UpdateMilestone(dto))
                {
                    return new AcceptedAtActionResult("put", "milestonecontroller", id, value);
                }
                else
                {
                    return new BadRequestObjectResult(false);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return new BadRequestObjectResult(ex);
            }
        }

        // DELETE api/<milestone>/5
        [HttpDelete("{id}")]
        public ObjectResult Delete([FromBody]string value)
        {
            try
            {
                MilestoneDTO dto = JsonConvert.DeserializeObject<MilestoneDTO>(value);
                if (repository.DeleteMilestone(dto))
                {
                    return new AcceptedAtActionResult("Delete", "MilestoneController", dto.Id, value);

                }
                else
                {
                    return new BadRequestObjectResult(false);
                }
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex);
                return new BadRequestObjectResult(false);
            }
        }
        [HttpPut("updatemilestonewithactivity/{userid}/{activityId}")]
        public ObjectResult UpdateMilestoneWithActivityId(int userid, int activityId, [FromBody]MilestoneProgressionDTO progressionDTO)
        {
            Console.WriteLine("Updating milstone with activity");
            MilestoneDTO dto = new MilestoneDTO();
            dto.ActivityId = activityId;
            dto.UserId = userid;
            try
            {
                repository.UpdateMilestoneWithActivityId(dto, progressionDTO);
                return new AcceptedResult("Milestone progression updated", progressionDTO.Value);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
