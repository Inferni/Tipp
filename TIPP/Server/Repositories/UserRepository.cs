using System;
using TIPP.Server.Domain;
using TIPP.Server.Services.SQLServices;
using TIPP.Shared;

namespace TIPP.Server.Repositories
{
    public class UserRepository : IUserRepository
    {
        
        private IUserService service;


        public UserRepository(tipp_DBContext context)
        {
            
            service = new UserSQLService(context);
        }

        public object GetUsers()
        {
            return service.GetUsers();
        }
        public UserDTO Authenticate(UserDTO dto)
        {
            User userToAuthenticate = new User(dto);
            Console.WriteLine(userToAuthenticate.Username);
            User authenticatedUser = service.Authenticate(userToAuthenticate);
            if(authenticatedUser == null)
            {
                return null;
            }
            else
            {
                return new UserDTO(authenticatedUser);
            }
        }

        public bool CreateUser(UserDTO dto)
        {
            User user = new User(dto);
            return service.CreateUser(user);
        }

        public UserDTO ReadUser(UserDTO dto)
        {
            User user = new User(dto);
            UserDTO retrievedUser = service.ReadUser(user);
            return retrievedUser;
        }
       

        public bool UpdateUser(UserDTO dto)
        {
            User user = new User(dto);
            return service.UpdateUser(user);
        }

        public bool DeleteUser(UserDTO dto)
        {
            User user = new User(dto);
            return service.DeleteUser(user);
        }
    }
}
