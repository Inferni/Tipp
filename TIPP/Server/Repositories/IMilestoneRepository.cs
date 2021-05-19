using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TIPP.Server.Domain;
using TIPP.Server.Domain.DTOs;

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
