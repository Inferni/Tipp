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
            if(projectToDelete !=null)
            {
                context.Projects.Remove(projectToDelete);
                List<ProjectUser> projectsInProjectUser = context.ProjectUsers.Where(x => x.Project.Equals(projectToDelete.Id)).ToList();
                Console.WriteLine("Deleting: " + projectToDelete.Name);
                
                foreach (var projectuser in projectsInProjectUser)
                {
                    context.ProjectUsers.Remove(projectuser);
                }
            }
            
            context.SaveChanges();
            return true;
        }

        public List<Project> GetProjects()
        {
            return context.Projects.ToList<Project>();
        }
        public List<ProjectUser> GetProjectsFromProjectUserByAdminId(UserDTO dto)
        {
            List<ProjectUser> projects = context.ProjectUsers.Where(x => x.User == dto.Id).ToList();
            return projects;
        }
        public List<Project> GetProjectsByUserId(UserDTO dto)
        {
            var projectIds = context.ProjectUsers.Where(x => x.User == dto.Id);
            List<Project> projectsfromdb = context.Projects.ToList();
            List<Project> projects = new List<Project>();
            foreach (ProjectUser projectid in projectIds)
            {
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

        public List<User>GetUsersByProjectId(ProjectDTO dto)
        {
            var userIds = context.ProjectUsers.Where(x => x.Project == dto.Id);
            List<User> usersInDb = context.Users.ToList();
            List<User> usersInProject = new List<User>();

            foreach(var userid  in userIds)
            {
                foreach (var user in usersInDb)
                {
                    if(userid.User.Equals(user.Id))
                    {
                        usersInProject.Add(user);
                    }
                }
            }

            return usersInProject;
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
                context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return false;
                throw;
            }
            return false;
        }

        public bool CreateUserProject(ProjectUser projectUser)
        {
            try
            {
                Console.WriteLine("Creating ProjectUser with ProjectId: "+ projectUser.ProjectNavigation.Id);
                Console.WriteLine("Creating ProjectUser with UserID: " + projectUser.UserNavigation.Id);
                projectUser.Project = projectUser.ProjectNavigation.Id;
                projectUser.User = projectUser.UserNavigation.Id;
                var response = context.ProjectUsers.Add(projectUser);
                context.SaveChanges();

                Console.WriteLine("Response: " + response);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return false;
                throw;
            }


        }

        public Project GetProjectById(int id)
        {
            return context.Projects.Where(x => x.Id .Equals(id)).FirstOrDefault();
        }
    }
}
