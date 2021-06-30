using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TIPP.Shared;

namespace TIPP.Client.Service
{
    interface IMilestoneDataService
    {
        Task<object> GetAllMilstones();
        Task<Milestone> GetMilestone(MilestoneDTO dto);
        Task<IList<Milestone>> GetMilestonesByActivityId(MilestoneDTO dto);
        Task<IList<ColleagueMilestoneDTO>> GetColleagueMilestonesByProjectID(int userid, int projectid);
        Task CreateMilestone(MilestoneDTO dto);
        Task UpdateMilestone(MilestoneDTO dto);
        Task DeleteMilestone(MilestoneDTO dto);
    }
}
