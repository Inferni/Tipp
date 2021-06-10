using System;
using System.Collections.Generic;
using System.Linq;
using TIPP.Server.Domain;
using TIPP.Shared;

namespace TIPP.Server.Services.SQLServices
{
    public class ActivitySQLService : IActivityService
    {
        private readonly tipp_DBContext context;

        public ActivitySQLService(tipp_DBContext context)
        {
            this.context = context;
        }

        public bool CreateActivity(Activity activity)
        {
            try
            {
                context.Activities.Add(activity);
                Console.WriteLine("Adding activity");

                context.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return false;
                
            }
            Console.WriteLine("Returning true");

            return true;
            
        }

        public bool DeleteActivity(Activity activity)
        {
            Activity activityToDelete;
            try
            {
                activityToDelete = context.Activities.Where(x => x.Id.Equals(activity.Id)).FirstOrDefault();
                context.Remove(activityToDelete);
                context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex);
                return false;

            }

            return true;
        }

        public object GetActivities()
        {
            return new { Items = context.Activities };
        }

        public List<Activity> GetActivitiesByProjectId(int id)
        {
            List<Activity> activites;
            try
            {
                activites = context.Activities.Where(x => x.ProjectId.Equals(id)).ToList();
                return activites;
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public ActivityDTO ReadActivity(Activity activity)
        {
            Activity activityRetrieved;
            try
            {
                activityRetrieved = context.Activities.Where(x => x.Id.Equals(activity.Id)).FirstOrDefault();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return null;
                
            }

            return new ActivityDTO(activityRetrieved);
        }

        public bool UpdateActivity(Activity activity)
        {
            Activity activityToUpdate;
            try
            {
                activityToUpdate = context.Activities.Where(x => x.Id.Equals(activity.Id)).FirstOrDefault();
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex);
                return false;
            }

            try
            {
                activityToUpdate.Id = activity.Id;
                activityToUpdate.Name = activity.Name;
                activityToUpdate.ProjectId = activity.ProjectId;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return false;
                
            }
            return true;
        }
    }
}
