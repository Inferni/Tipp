using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
using TIPP.Shared;

namespace TIPP.Client.Service
{
    interface IUserDataService
    {
        Task<object> GetAllUsers();
        Task<string> GetUser(UserDTO dto);
        Task<ObjectResult> CreateUser(UserDTO dto);
        Task<ObjectResult> UpdateUser(UserDTO dto);
        Task<ObjectResult> DeleteUser(UserDTO dto);
    }
}
