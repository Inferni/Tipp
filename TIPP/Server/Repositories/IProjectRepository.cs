using TIPP.Shared;

namespace TIPP.Server.Repositories
{
    interface IProjectRepository
    {
        object GetProjects();
        bool CreateProject(ProjectDTO dto);
        ProjectDTO ReadProject(ProjectDTO dto);
        bool UpdateProject(ProjectDTO dto);
        bool DeleteProject(ProjectDTO dto);
    }
}
