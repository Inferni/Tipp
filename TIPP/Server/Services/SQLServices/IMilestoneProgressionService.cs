using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TIPP.Shared;

namespace TIPP.Server.Services.SQLServices
{
    interface IMilestoneProgressionService
    {
        object GetMilestoneProgession();
        bool CreateMilestone(MilestoneProgression milestone);
        MilestoneProgressionDTO ReadMilestoneProgression(MilestoneProgression milestone);
        bool UpdateMilestoneProgression(MilestoneProgression milestone);
        bool DeleteMilestoneProgression(MilestoneProgression milestone);
        List<MilestoneProgression> GetProjectProgressionWithUserId(UserDTO dto);
        List<MilestoneProgression> GetProgressionWithMilestoneId(MilestoneProgressionDTO dto);
    }
}
