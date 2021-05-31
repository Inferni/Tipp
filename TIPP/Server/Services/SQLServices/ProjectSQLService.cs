using System;
using System.Collections.Generic;
using System.Linq;
using TIPP.Server.Domain;
using TIPP.Shared;

namespace TIPP.Server.Services.SQLServices
{
    public class ProjectSQLService : IProjectService
    {
        private readonly tipp_DBContext context;

        public ProjectSQLService(tipp_DBContext context)
        {
            this.context = context;
        }


        public bool CreateProject(Project project)
        {
            try
            {
                context.Projects.Add(project);
                context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return false;
                
            }
            
        }

        public bool DeleteProject(Project project)
        {
            Project projectToDelete;
            try
            {
                projectToDelete = context.Projects.Where(x => x.Id.Equals(project.Id)).FirstOrDefault();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return false;
                
            }
            context.Projects.Remove(projectToDelete);
            return true;
        }

        public object GetProjects()
        {
            return new { Items = context.Projects };
        }

        public object GetProjectsByUserId(UserDTO dto)
        {
            var projectIds = context.ProjectUsers.Where(x => x.User == dto.Id);
            List<Project> projectsfromdb = context.Projects.ToList();
            List<Project> projects = new List<Project>();
            foreach (ProjectUser projectid in projectIds)
            {
                Console.WriteLine(projectid.Project);
                foreach (Project project in projectsfromdb)
                {
                    if (projectid.Project.Equals(project.Id))
                    {
                        projects.Add(project);
                    }
                }
            }
            //object projects = context.Projects.Where(x => x.Id.Equals( projectIds));
            return projects;
        }

        public ProjectDTO ReadProject(Project project)
        {
            Project projectRetrieved;
            try
            {
                projectRetrieved = context.Projects.Where(x => x.Id.Equals(project.Id)).FirstOrDefault();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return null;

            }

            return new ProjectDTO(projectRetrieved);
        }

        public bool UpdateProject(Project project)
        {
            Project projectToUpdate;
            try
            {
                projectToUpdate = context.Projects.Where(x => x.Id.Equals(project.Id)).FirstOrDefault();
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex);
                return false;
            }

            try
            {
                projectToUpdate.Id = project.Id;
                projectToUpdate.Name = project.Name;
                projectToUpdate.Completed = project.Completed;
                projectToUpdate.Activities = project.Activities;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return false;
                throw;
            }
            return true;
        }
    }
}
