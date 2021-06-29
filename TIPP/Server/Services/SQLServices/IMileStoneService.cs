using System.Collections.Generic;
using TIPP.Shared;

namespace TIPP.Server.Services.SQLServices
{
    interface IMileStoneService
    {
        object GetMilestones();
        Milestone GetMilestoneById(MilestoneDTO dto);
        List<Milestone> GetMilestonesByActivityID(MilestoneDTO dto);
        Milestone CreateMilestone(Milestone milestone);
        MilestoneDTO ReadMilestone(Milestone milestone);
        bool UpdateMilestone(Milestone milestone);
        bool DeleteMilestone(Milestone milestone);
        List<ColleagueMilestoneDTO> GetColleagueMilestonesByProjectID(int UserId, ProjectDTO dto);
    }
}
