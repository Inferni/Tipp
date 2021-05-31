using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using TIPP.Shared;

namespace TIPP.Client.Service
{
    public interface IUserDataService
    {
        Models.User User { get; }
        Task<object> GetAllUsers();
        Task<IList<Models.User>> GetAllUsersByProjectId(ProjectDTO dto);
        Task Initialize();
        Task<string> GetUser(UserDTO dto);
        Task<ObjectResult> CreateUser(UserDTO dto);
        Task<ObjectResult> UpdateUser(UserDTO dto);
        Task<ObjectResult> DeleteUser(UserDTO dto);
    }
}
