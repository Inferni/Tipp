using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TIPP.Server.Domain;
using TIPP.Server.Domain.DTOs;
using TIPP.Server.Services.SQLServices;
using TIPP.Shared.Test;

namespace TIPP.Server.Repositories
{
    public class UserRepository : IUserRepository
    {
        
        private static UserRepository self;
        private IUserService service;

        private UserRepository()
        {
            
            service = new UserSQLService();
        }

        public static UserRepository GetRepository()
        {
            if(self != null)
            {
                return self;
            }
            else
            {
                self = new UserRepository();
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
