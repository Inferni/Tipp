using System.Collections.Generic;
using TIPP.Shared;

namespace TIPP.Server.Repositories
{
    interface IActivityRepository
    {
        object GetActivities();
        List<Activity> GetActivitiesByProjectId(int id);
        bool CreateActivity(ActivityDTO dto);
        ActivityDTO ReadActivity(ActivityDTO dto);
        bool UpdateActivity(ActivityDTO dto);
        bool DeleteActivity(ActivityDTO dto);
    }
}
