using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TIPP.Server.Domain;
using TIPP.Server.Repositories;
using TIPP.Server.Services.SQLServices;
using TIPP.Shared;

namespace TIPP.Server.Helpers
{
    public class ProjectRepositoryHelper
    {
        private IProjectService service;
        private IUserRepositoryProjectRepository userRepo;


        public ProjectRepositoryHelper(tipp_DBContext context)
        {
            this.service = new ProjectSQLService(context);
             userRepo = new UserRepository(context);

        }

        public bool AddProjectUserAfterProjectCreation(ProjectDTO dto)
        {
            Console.WriteLine("Getting Projects");

            List<Project> projects = service.GetProjects();
            List<int> projectIds = new List<int>();
            foreach (var project in projects)
            {
                projectIds.Add(project.Id);
                Console.WriteLine(project.Id);

            }

            UserDTO adminDTO = new UserDTO(dto.AdminID);
            Console.WriteLine("Getting projectusers: " + dto.AdminID);
            List<ProjectUser> projectByUser = service.GetProjectsFromProjectUserByAdminId(adminDTO);
            Console.WriteLine(projectByUser.Count);
            List<int> projectByUserIds = new List<int>();


            foreach (var project in projectByUser)
            {
                projectByUserIds.Add(project.Project);
                Console.WriteLine(project.Project);
            }

            Console.WriteLine("Cross referencing");
            foreach (var projectId in projectIds)
            {
                if (!projectByUserIds.Contains(projectId))
                {
                    Console.WriteLine($"ProjectID: {projectId}");
                    Project project = service.GetProjectById(projectId);
                    Console.WriteLine("Project: " + project.Name);
                    User user = userRepo.GetUserById(adminDTO);
                    Console.WriteLine("User: " + user.Username);
                    ProjectUser toAdd = new ProjectUser();
                    toAdd.ProjectNavigation = project;
                    toAdd.UserNavigation = user;
                    return service.CreateUserProject(toAdd);
                }
            }
            return false;
        }
    }
}
