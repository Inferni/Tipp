using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TIPP.Server.Domain;
using TIPP.Server.Domain.DTOs;

namespace TIPP.Server.Services.SQLServices
{
    interface IUserService
    {
        object GetUsers();
        bool CreateUser(User user);
        UserDTO ReadUser(User user);
        bool UpdateUser(User user);
        bool DeleteUser(User user);
    }
}
