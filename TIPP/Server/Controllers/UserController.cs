using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Threading.Tasks;
using TIPP.Server.Domain;
using TIPP.Server.Repositories;
using TIPP.Shared;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TIPP.Server.Controllers
{
    [Route("api/user")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private IUserRepository repository;
        public UserController(tipp_DBContext context)
        {
            this.repository = new UserRepository(context);

        }

        // GET: api/<UserController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            Console.WriteLine("Getting from API");
            var result = JsonConvert.SerializeObject(repository.GetUsers());

            return Ok(result);
        }

        // GET api/<UserController>/5
        [HttpGet("{id}")]
        public string Get([FromBody]string value)
        {
            try
            {
                UserDTO dto = JsonConvert.DeserializeObject<UserDTO>(value);
                UserDTO retrievedUser = repository.ReadUser(dto);
                return JsonConvert.SerializeObject(retrievedUser);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return null;
            }
            
        }

        [HttpPost("authenticate")]
        // POST api/<user>/authenticate
        public async Task<IActionResult> Login([FromBody]UserDTO value)
        {
            Console.WriteLine(value.Username);
            UserDTO authenticatedUser;
            try
            {
                authenticatedUser = repository.Authenticate(value);
            }
            catch (Exception ex)
            {

                throw;
            }

            if(authenticatedUser==null)
            {
                return new BadRequestObjectResult("Username or Password incorrect");
            }
            else
            {
                var json = JsonConvert.SerializeObject(authenticatedUser);
                return Ok(json);
            }
        }

        // POST api/<UserController>
        [HttpPost]
        public ObjectResult Post([FromBody] string value)
        {
            try
            {
                UserDTO dto = JsonConvert.DeserializeObject<UserDTO>(value);
                if(repository.CreateUser(dto))
                {
                    return new AcceptedAtActionResult("Post", "UserController", value, value);

                }
                else
                {
                    return new BadRequestObjectResult(false);
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex);
                return new BadRequestObjectResult(ex);
            }
            


        }

        // PUT api/<UserController>/5
        [HttpPut("{id}")]
        public ObjectResult Put(int id, [FromBody] string value)
        {
            try
            {
                UserDTO dto = JsonConvert.DeserializeObject<UserDTO>(value);
                if(repository.UpdateUser(dto))
                {
                    return new AcceptedAtActionResult("Put", "UserController", id, value);

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

        // DELETE api/<UserController>/5
        [HttpDelete("{id}")]
        public ObjectResult Delete([FromBody] string value)
        {
            try
            {
                UserDTO dto = JsonConvert.DeserializeObject<UserDTO>(value);
                if(repository.DeleteUser(dto))
                {
                    return new AcceptedAtActionResult("Delete", "UserController", dto.Id, value);
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
