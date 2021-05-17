using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TIPP.Server.Domain;
using TIPP.Server.Domain.DTOs;

namespace TIPP.Server.Repositories
{
    interface IUserRepository
    {
        object GetUsers();
        bool CreateUser(UserDTO dto);
        UserDTO ReadUser(UserDTO dto);
        bool UpdateUser(UserDTO dto);
        bool DeleteUser(UserDTO dto);

    }
}
