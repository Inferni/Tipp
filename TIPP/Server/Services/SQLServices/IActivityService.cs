using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TIPP.Server.Domain;
using TIPP.Server.Domain.DTOs;

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
