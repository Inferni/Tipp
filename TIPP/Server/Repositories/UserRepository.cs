using TIPP.Server.Domain;
using TIPP.Server.Services.SQLServices;
using TIPP.Shared;

namespace TIPP.Server.Repositories
{
    public class UserRepository : IUserRepository
    {
        
        private static UserRepository self;
        private IUserService service;


        public UserRepository(tipp_DBContext context)
        {
            
            service = new UserSQLService(context);
        }

        public static UserRepository GetRepository(tipp_DBContext context)
        {
            if(self != null)
            {
                return self;
            }
            else
            {
                self = new UserRepository(context);
                return self;
            }
        }

        public object GetUsers()
        {
            return service.GetUsers();
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
