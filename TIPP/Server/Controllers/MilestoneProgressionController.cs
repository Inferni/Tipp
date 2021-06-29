using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TIPP.Server.Domain;
using TIPP.Server.Repositories;
using TIPP.Shared;

namespace TIPP.Server.Controllers
{
    [Route("api/milestone/progression")]
    [ApiController]
    public class MilestoneProgressionController
    {
        IMilestoneProgressionRepository repository;

        public MilestoneProgressionController(tipp_DBContext context)
        {
            repository = new MilestoneProgressionRepository(context);
        }

        // GET: api/<project>
        [HttpGet]
        public string GetAll()
        {
            return JsonConvert.SerializeObject(repository.GetMilestoneProgession());
        }

        // GET api/<project>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            try
            {
                MilestoneProgressionDTO dto = new MilestoneProgressionDTO();
                dto.Id = id;
                return JsonConvert.SerializeObject(repository.ReadMilestoneProgression(dto));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return null;

            }

        }

        // POST api/<project>
        [HttpPost]
        public ObjectResult Post([FromBody] MilestoneProgressionDTO value)
        {
            try
            {
                //ProjectDTO dto = JsonConvert.DeserializeObject<ProjectDTO>(value);

                if (repository.CreateMilestoneProgession(value))
                {

                    return new AcceptedResult("MilestoneProgession", value);
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

        // PUT api/<project>/5
        [HttpPut("{id}")]
        public ObjectResult Put(int id, [FromBody] MilestoneProgressionDTO dto)
        {
            try
            {
                //ProjectDTO dto = JsonConvert.DeserializeObject<ProjectDTO>(value);
                if (repository.UpdateMilestoneProgression(dto))
                {
                    return new AcceptedResult("Project", dto);
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

        // DELETE api/<project>/5
        [HttpDelete("{id}")]
        public ObjectResult Delete(int id)
        {
            Console.WriteLine("Deleting: " + id);
            try
            {
                MilestoneProgressionDTO dto = new MilestoneProgressionDTO(id);
                if (repository.DeleteMilestoneProgression(dto))
                {
                    return new AcceptedResult("Milestoneprogression delete", dto);
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

        [HttpGet("getprogressionwithuser/{id}/{projectid}")]
        public string GetProjectProgressionWithUserId(int id, int projectid)
        {
            Console.WriteLine("getprogressionwithuser");
            UserDTO dto = new UserDTO();
            dto.Id = id;
            dto.ProjectID = projectid;
            try
            {
                return JsonConvert.SerializeObject(repository.GetProjectProgressionWithUserId(dto));
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        [HttpGet("GetByMilestoneId/{milestoneid}")]
        public string GetProgressionWithMilestoneId(int milestoneid)
        {
            MilestoneProgressionDTO dto = new MilestoneProgressionDTO();
            dto.MilestoneId = milestoneid;
            return JsonConvert.SerializeObject(repository.GetProgressionWithMilestoneId(dto));

        }
    }
}
