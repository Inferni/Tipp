using System.Collections.Generic;
using TIPP.Server.Domain;
using TIPP.Shared;

namespace TIPP.Server.Services.SQLServices
{
    interface IProjectService
    {
        List<Project> GetProjects();
        Project GetProjectById(int id);
        List<Project> GetProjectsByUserId(UserDTO dto);
        List<ProjectUser> GetProjectsFromProjectUserByAdminId(UserDTO dto);
        List<User> GetUsersByProjectId(ProjectDTO dto);
        bool CreateProject(Project project);

        bool CreateUserProject(ProjectUser projectUser);
        ProjectDTO ReadProject(Project project);
        bool UpdateProject(Project project);
        bool DeleteProject(Project project);
    }
}
