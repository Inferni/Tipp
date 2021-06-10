using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TIPP.Server.Domain;
using TIPP.Shared;

namespace TIPP.Server.Services.SQLServices
{
    public class MilestoneProgressionSQLService : IMilestoneProgressionService
    {
        private readonly tipp_DBContext context;

        public MilestoneProgressionSQLService(tipp_DBContext context)
        {
            this.context = context;
        }

        public bool CreateMilestone(MilestoneProgression milestone)
        {
            throw new NotImplementedException();
        }

        public bool DeleteMilestoneProgression(MilestoneProgression milestone)
        {
            throw new NotImplementedException();
        }

        public object GetMilestoneProgession()
        {
            throw new NotImplementedException();
        }

        public MilestoneProgressionDTO ReadMilestoneProgression(MilestoneProgression milestone)
        {
            throw new NotImplementedException();
        }

        public bool UpdateMilestoneProgression(MilestoneProgression milestone)
        {
            throw new NotImplementedException();
        }
    }
}
