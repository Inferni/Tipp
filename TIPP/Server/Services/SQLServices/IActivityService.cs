using System.Collections.Generic;
using TIPP.Shared;

namespace TIPP.Server.Services.SQLServices
{
    interface IActivityService
    {
        object GetActivities();
        List<Activity> GetActivitiesByProjectId(int id);
        bool CreateActivity(Activity activity);
        ActivityDTO ReadActivity(Activity activity);
        bool UpdateActivity(Activity activity);
        bool DeleteActivity(Activity activity);
    }
}
