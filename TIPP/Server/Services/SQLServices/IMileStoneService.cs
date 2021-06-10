using System.Collections.Generic;
using TIPP.Shared;

namespace TIPP.Server.Services.SQLServices
{
    interface IMileStoneService
    {
        object GetMilestones();
        List<Milestone> GetMilestonesByActivityID(MilestoneDTO dto);
        bool CreateMilestone(Milestone milestone);
        MilestoneDTO ReadMilestone(Milestone milestone);
        bool UpdateMilestone(Milestone milestone);
        bool DeleteMilestone(Milestone milestone);
    }
}
