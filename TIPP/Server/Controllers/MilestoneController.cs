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
    [Route("api/[[milestone]]")]
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
                if(repository.CreateMilestone(dto))
                {
                    return new AcceptedResult("Milestone", value);
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
    }
}
