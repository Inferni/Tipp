using Microsoft.AspNetCore.Mvc;
using System;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TIPP.Server.Domain;
using TIPP.Server.Repositories;
using TIPP.Shared;

namespace TIPP.Server.Controllers
{
    [Route("api/thumbsup")]
    [ApiController]
    public class ThumbsUpController:ControllerBase
    {
        private readonly IThumbsUpRepository repository;

        public ThumbsUpController(tipp_DBContext context)
        {
            this.repository = new ThumbsUpRepository(context);
        }

        [HttpPost]
        public ObjectResult Post([FromBody] ThumbsUpDTO value)
        {
            Console.WriteLine("Posting activity");
            try
            {
                if (repository.CreateThumbsUp(value))
                {
                    Console.WriteLine("Returning activity");

                    return new AcceptedResult("Activity", value.MilestoneId);
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

        [HttpGet("GetThumbsUpsByProjectAndUserId/{projectid}/{userid}")]
        public string GetThumbsUpsByProjectAndUserId(int projectid, int userid)
        {
            return JsonConvert.SerializeObject(repository.GetThumbsUpsByProjectAndUserId(projectid, userid));
                
        }

        // PUT api/<project>/5
        [HttpPut("{id}")]
        public ObjectResult Put(int id, [FromBody] ThumbsUpDTO dto)
        {
            try
            {
                //ProjectDTO dto = JsonConvert.DeserializeObject<ProjectDTO>(value);
                if (repository.UpdateThumbsUp(dto))
                {
                    return new AcceptedResult("Thumbs Up Updated", dto.MilestoneName);
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
