﻿using Microsoft.AspNetCore.Mvc;
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
    [Route("api/[activitycontroller]")]
    [ApiController]
    public class ActivityController : ControllerBase
    {
        private IActivityRepository repository = ActivityRepository.GetActivityRepository();
        // GET: api/<ActivityController>
        [HttpGet]
        public object GetAll()
        {
            return JsonConvert.SerializeObject(repository.GetActivities());
        }

        // GET api/<ActivityController>/5
        [HttpGet("{id}")]
        public string Get([FromBody] string value)
        {
            try
            {
                ActivityDTO dto = JsonConvert.DeserializeObject<ActivityDTO>(value);
                return JsonConvert.SerializeObject(repository.ReadActivity(dto));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return null;
                
            }
        }

        // POST api/<ActivityController>
        [HttpPost]
        public ObjectResult Post([FromBody] string value)
        {
            try
            {
                ActivityDTO dto = JsonConvert.DeserializeObject<ActivityDTO>(value);
                if(repository.CreateActivity(dto))
                {
                    return new AcceptedResult("Activity", value);
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

        // PUT api/<ActivityController>/5
        [HttpPut("{id}")]
        public ObjectResult Put(int id, [FromBody] string value)
        {
            try
            {
                ActivityDTO dto = JsonConvert.DeserializeObject<ActivityDTO>(value);
                if (repository.UpdateActivity(dto))
                {
                    return  new AcceptedResult("Activity", value);
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

        // DELETE api/<ActivityController>/5
        [HttpDelete("{id}")]
        public ObjectResult Delete([FromBody] string value)
        {
            try
            {
                ActivityDTO dto = JsonConvert.DeserializeObject<ActivityDTO>(value);
                if (repository.DeleteActivity(dto))
                {
                    return new AcceptedResult("Activity", value);
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
