using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TIPP.Shared;

namespace TIPP.Client.Service
{
    public interface IProjectDataService
    {
        TIPP.Shared.Project Project { get; }
        Task<object> GetAllProjects();
        Task<IList<TIPP.Shared.Project>> GetAllProjectsByUserId(UserDTO dto);
        Task Initialize();
        Task<string> GetProject(ProjectDTO dto);
        Task<ObjectResult> CreateProject(ProjectDTO dto);
        Task<ObjectResult> UpdateProject(ProjectDTO dto);
        Task<ObjectResult> DeleteProject(ProjectDTO dto);
    }
}
