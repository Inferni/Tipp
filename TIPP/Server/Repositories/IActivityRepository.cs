using TIPP.Shared;

namespace TIPP.Server.Repositories
{
    interface IActivityRepository
    {
        object GetActivities();
        bool CreateActivity(ActivityDTO dto);
        ActivityDTO ReadActivity(ActivityDTO dto);
        bool UpdateActivity(ActivityDTO dto);
        bool DeleteActivity(ActivityDTO dto);
    }
}
