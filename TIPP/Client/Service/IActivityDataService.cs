using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TIPP.Shared;

namespace TIPP.Client.Service
{
    interface IActivityDataService
    {
        Task<object> GetAllActivities();
        Task<Activity> GetActivity(ActivityDTO dto);
        Task<IList<Activity>> GetActivitiesByProjectId(ActivityDTO dto);
        Task CreateActivity(ActivityDTO dto);
        Task UpdateActivity(ActivityDTO dto);
        Task DeleteActivity(ActivityDTO dto);
    }
}
