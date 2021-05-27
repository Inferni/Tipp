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
    [Route("api/[[project]]")]
    [ApiController]
    public class ProjectController : ControllerBase
    {

        private IProjectRepository repository;

        public ProjectController(tipp_DBContext context)
        {
            repository = new ProjectRepository(context);
        }

        // GET: api/<project>
        [HttpGet]
        public object GetAll()
        {
            return JsonConvert.SerializeObject(repository.GetProjects());
        }

        // GET api/<project>/5
        [HttpGet("{id}")]
        public string Get([FromBody]string value)
        {
            try
            {
                ProjectDTO dto = JsonConvert.DeserializeObject<ProjectDTO>(value);
                return JsonConvert.SerializeObject(repository.ReadProject(dto));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return null;
                
            }
            
        }

        // POST api/<project>
        [HttpPost]
        public ObjectResult Post([FromBody] string value)
        {
            try
            {
                ProjectDTO dto = JsonConvert.DeserializeObject<ProjectDTO>(value);

                if(repository.CreateProject(dto))
                {
                    return new AcceptedResult("Project", value);
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
        public ObjectResult Put(int id, [FromBody] string value)
        {
            try
            {
                ProjectDTO dto = JsonConvert.DeserializeObject<ProjectDTO>(value);
                if(repository.UpdateProject(dto))
                {
                    return new AcceptedResult("Project", value);
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
        public ObjectResult Delete([FromBody]string value)
        {
            try
            {
                ProjectDTO dto = JsonConvert.DeserializeObject<ProjectDTO>(value);
                if (repository.DeleteProject(dto))
                {
                    return new AcceptedResult("Project", value);
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
