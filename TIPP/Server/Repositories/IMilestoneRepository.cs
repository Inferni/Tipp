using TIPP.Shared;

namespace TIPP.Server.Repositories
{
    interface IMilestoneRepository
    {
        object GetMilestones();
        bool CreateMilestone(MilestoneDTO dto);
        MilestoneDTO ReadMilestone(MilestoneDTO dto);
        bool UpdateMilestone(MilestoneDTO dto);
        bool DeleteMilestone(MilestoneDTO dto);
    }
}
