using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TIPP.Server.Domain;
using TIPP.Server.Domain.DTOs;
using TIPP.Server.Services.SQLServices;
using TIPP.Shared;

namespace TIPP.Server.Repositories
{
    public class ProjectRepository : IProjectRepository
    {
        private static ProjectRepository self;
        private IProjectService service;

        private ProjectRepository()
        {
            service = new ProjectSQLService();
        }

        public static ProjectRepository GetProjectRepository()
        {
            if(self !=null)
            {
                return self;
            }
            else
            {
                self = new ProjectRepository();
                return self;
            }
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
