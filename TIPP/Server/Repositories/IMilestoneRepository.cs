using System.Collections.Generic;
using TIPP.Shared;

namespace TIPP.Server.Repositories
{
    interface IMilestoneRepository
    {
        object GetMilestones();
        List<MilestoneDTO> GetMilestonesByActivityId(MilestoneDTO dto);
        void UpdateMilestoneWithActivityId(MilestoneDTO dto, MilestoneProgressionDTO progressionDTO);
        MilestoneDTO CreateMilestone(MilestoneDTO dto);
        MilestoneDTO ReadMilestone(MilestoneDTO dto);
        bool UpdateMilestone(MilestoneDTO dto);
        bool DeleteMilestone(MilestoneDTO dto);
    }
}
