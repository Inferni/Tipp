using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TIPP.Server.Domain;
using TIPP.Server.Domain.DTOs;

namespace TIPP.Server.Services.SQLServices
{
    interface IMileStoneService
    {
        object GetMilestones();
        bool CreateMilestone(Milestone milestone);
        MilestoneDTO ReadMilestone(Milestone milestone);
        bool UpdateMilestone(Milestone milestone);
        bool DeleteMilestone(Milestone milestone);
    }
}
