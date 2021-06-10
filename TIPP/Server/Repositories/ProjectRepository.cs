using System;
using System.Collections.Generic;
using TIPP.Server.Domain;
using TIPP.Server.Helpers;
using TIPP.Server.Services.SQLServices;
using TIPP.Shared;

namespace TIPP.Server.Repositories
{
    public class ProjectRepository : IProjectRepository, IProjectRepositoryActivityRepository
    {
        private IProjectService service;
        private ProjectRepositoryHelper helper;

        public ProjectRepository(tipp_DBContext context)
        {
            service = new ProjectSQLService(context);
            helper = new ProjectRepositoryHelper(context);
        }

        public bool CreateProject(ProjectDTO dto)
        {
            Console.WriteLine("Creating Project");
            if(service.CreateProject(new Project(dto)))
            {
                return helper.AddProjectUserAfterProjectCreation(dto);             
            }
            else
            {
                return false;
            }

            return false;
        }

        public bool DeleteProject(ProjectDTO dto)
        {
            return service.DeleteProject(new Project(dto));
        }

        public Project GetProjectById(int id)
        {
            return service.GetProjectById(id);
        }

        public List<Project> GetProjects()
        {
            return service.GetProjects();
        }
        public List<Project> GetProjectsByUserId(UserDTO dto)
        {
            return service.GetProjectsByUserId(dto);
        }

        public List<User> GetUsersByProjectId(ProjectDTO dto)
        {
            return service.GetUsersByProjectId(dto);
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
