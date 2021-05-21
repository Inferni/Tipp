using TIPP.Shared;

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
