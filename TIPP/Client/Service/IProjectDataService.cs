using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TIPP.Client.Models;
using TIPP.Shared;

namespace TIPP.Client.Service
{
    public interface IProjectDataService
    {
        TIPP.Shared.Project Project { get; }
        Task<object> GetAllProjects();
        Task<IList<TIPP.Shared.Project>> GetAllProjectsByUserId(UserDTO dto);
        Task<IList<TIPP.Shared.User>> GetUsersByProjectId(ProjectDTO dto);
        Task Initialize();
        Task<Project> GetProject(ProjectDTO dto);
        Task CreateProject(AddProject dto);
        Task UpdateProject(ProjectDTO dto);
        Task DeleteProject(ProjectDTO dto);
    }
}
