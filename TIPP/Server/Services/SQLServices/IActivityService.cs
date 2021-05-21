using TIPP.Shared;

namespace TIPP.Server.Services.SQLServices
{
    interface IActivityService
    {
        object GetActivities();
        bool CreateActivity(Activity activity);
        ActivityDTO ReadActivity(Activity activity);
        bool UpdateActivity(Activity activity);
        bool DeleteActivity(Activity activity);
    }
}
