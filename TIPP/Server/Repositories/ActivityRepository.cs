using System;
using System.Collections.Generic;
using TIPP.Server.Domain;
using TIPP.Server.Services.SQLServices;
using TIPP.Shared;

namespace TIPP.Server.Repositories
{
    public class ActivityRepository:IActivityRepository
    {
        private IActivityService service;
        private IProjectRepositoryActivityRepository projectRepository;

        public ActivityRepository(tipp_DBContext context)
        {
            service = new ActivitySQLService(context);
            projectRepository = new ProjectRepository(context);
        }


        public bool CreateActivity(ActivityDTO dto)
        {
            Console.WriteLine("Creating Activity");
            Console.WriteLine("Getting project");

            Project project = projectRepository.GetProjectById(dto.ProjectId);
            dto.Project = project;
            return service.CreateActivity(new Activity(dto));
        }

        public bool DeleteActivity(ActivityDTO dto)
        {
            return service.DeleteActivity(new Activity(dto));
        }

        public object GetActivities()
        {
            return service.GetActivities();
        }

        public List<Activity> GetActivitiesByProjectId(int id)
        {
            return service.GetActivitiesByProjectId(id);
        }

        public ActivityDTO ReadActivity(ActivityDTO dto)
        {
            return service.ReadActivity(new Activity(dto));
        }

        public bool UpdateActivity(ActivityDTO dto)
        {
            return service.UpdateActivity(new Activity(dto));
        }
    }
}
