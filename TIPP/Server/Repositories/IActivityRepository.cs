using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TIPP.Server.Domain.DTOs;
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
