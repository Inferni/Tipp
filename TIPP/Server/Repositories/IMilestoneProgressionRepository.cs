using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TIPP.Shared;

namespace TIPP.Server.Repositories
{
    public interface IMilestoneProgressionRepository
    {
        object GetMilestoneProgession();
        bool CreateMilestoneProgession(MilestoneProgressionDTO milestone);
        MilestoneProgressionDTO ReadMilestoneProgression(MilestoneProgressionDTO milestone);
        bool UpdateMilestoneProgression(MilestoneProgressionDTO milestone);
        bool DeleteMilestoneProgression(MilestoneProgressionDTO milestone);
        List<MilestoneProgression> GetProjectProgressionWithUserId(UserDTO dto);
    }
}
