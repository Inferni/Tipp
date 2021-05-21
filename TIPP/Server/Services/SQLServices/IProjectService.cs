using TIPP.Shared;

namespace TIPP.Server.Services.SQLServices
{
    interface IProjectService
    {
        object GetProjects();
        bool CreateProject(Project project);
        ProjectDTO ReadProject(Project project);
        bool UpdateProject(Project project);
        bool DeleteProject(Project project);
    }
}
