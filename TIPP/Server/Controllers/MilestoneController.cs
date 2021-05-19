using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TIPP.Server.Domain.DTOs;
using TIPP.Server.Repositories;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TIPP.Server.Controllers
{
    [Route("api/[milestonecontroller]")]
    [ApiController]
    public class MilestoneController : ControllerBase
    {
        private IMilestoneRepository repository = MilestoneRepository.GetMilestoneRepository();
        // GET: api/<MilestoneController>
        [HttpGet]
        public string GetAll()
        {
            return JsonConvert.SerializeObject(repository.GetMilestones());
        }

        // GET api/<MilestoneController>/5
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

        // POST api/<MilestoneController>
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

        // PUT api/<MilestoneController>/5
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

        // DELETE api/<MilestoneController>/5
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
