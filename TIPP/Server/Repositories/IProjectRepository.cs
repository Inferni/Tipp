using System.Collections.Generic;
using TIPP.Shared;

namespace TIPP.Server.Repositories
{
    interface IProjectRepository
    {
        List<Project> GetProjects();
        List<Project> GetProjectsByUserId(UserDTO dto);
        List<User> GetUsersByProjectId(ProjectDTO dto);
        bool CreateProject(ProjectDTO dto);
        ProjectDTO ReadProject(ProjectDTO dto);
        bool UpdateProject(ProjectDTO dto);
        bool DeleteProject(ProjectDTO dto);
    }
}
