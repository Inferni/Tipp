using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TIPP.Shared;

namespace TIPP.Client.Service
{
    public interface IMilestoneProgressionService
    {
        Task<object> GetAllProjects();
        Task<IList<TIPP.Shared.MilestoneProgression>> GetAllMilestoneProgressionssByUserId(UserDTO dto);

        Task<MilestoneProgression> GetMilestoneProgression(MilestoneProgressionDTO dto);
        Task CreateMilestoneProgression(MilestoneProgressionDTO dto);
        Task UpdateMilestoneProgression(MilestoneProgressionDTO dto);
        Task DeleteMilestoneProgression(MilestoneProgressionDTO dto);
    }
}
