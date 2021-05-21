using TIPP.Server.Services.SQLServices;
using TIPP.Shared;

namespace TIPP.Server.Repositories
{
    public class ActivityRepository:IActivityRepository
    {
        private static ActivityRepository self;
        private IActivityService service;

        private ActivityRepository()
        {
            service = new ActivitySQLService();
        }

        public static ActivityRepository GetActivityRepository()
        {
            if(self!=null)
            {
                return self;
            }
            else
            {
                self = new ActivityRepository();
                return self;
            }
        }

        public bool CreateActivity(ActivityDTO dto)
        {
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
