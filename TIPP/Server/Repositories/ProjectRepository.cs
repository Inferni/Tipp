using TIPP.Server.Domain;
using TIPP.Server.Services.SQLServices;
using TIPP.Shared;

namespace TIPP.Server.Repositories
{
    public class ProjectRepository : IProjectRepository
    {
        private IProjectService service;

        public ProjectRepository(tipp_DBContext context)
        {
            service = new ProjectSQLService(context);
        }

        public bool CreateProject(ProjectDTO dto)
        {
            return service.CreateProject(new Project(dto));
        }

        public bool DeleteProject(ProjectDTO dto)
        {
            return service.DeleteProject(new Project(dto));
        }

        public object GetProjects()
        {
            return service.GetProjects();
        }

        public ProjectDTO ReadProject(ProjectDTO dto)
        {
            return service.ReadProject(new Project(dto));
        }

        public bool UpdateProject(ProjectDTO dto)
        {
            return service.UpdateProject(new Project(dto));
        }
    }
}
