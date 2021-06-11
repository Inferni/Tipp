using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TIPP.Server.Domain;
using TIPP.Server.Services.SQLServices;
using TIPP.Shared;

namespace TIPP.Server.Repositories
{
    public class MilestoneProgressionRepository : IMilestoneProgressionRepository
    {
        private IMilestoneProgressionService service;

        public MilestoneProgressionRepository(tipp_DBContext context)
        {
            this.service = new MilestoneProgressionSQLService(context);
        }

        public bool CreateMilestoneProgession(MilestoneProgressionDTO milestone)
        {
            throw new NotImplementedException();
        }

        public bool DeleteMilestoneProgression(MilestoneProgressionDTO milestone)
        {
            throw new NotImplementedException();
        }

        public object GetMilestoneProgession()
        {
            throw new NotImplementedException();
        }

        public MilestoneProgressionDTO ReadMilestoneProgression(MilestoneProgressionDTO milestone)
        {
            throw new NotImplementedException();
        }

        public bool UpdateMilestoneProgression(MilestoneProgressionDTO milestone)
        {
            throw new NotImplementedException();
        }

        public List<MilestoneProgression> GetProjectProgressionWithUserId(UserDTO dto)
        {
            return service.GetProjectProgressionWithUserId(dto);
        }
    }
}
