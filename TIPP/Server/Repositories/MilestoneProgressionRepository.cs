using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TIPP.Server.Domain;
using TIPP.Server.Helpers;
using TIPP.Server.Services.SQLServices;
using TIPP.Shared;

namespace TIPP.Server.Repositories
{
    public class MilestoneProgressionRepository : IMilestoneProgressionRepository
    {
        private IMilestoneProgressionService service;
        private MilestoneCompletionHelper completionHelper;

        public MilestoneProgressionRepository(tipp_DBContext context)
        {
            this.service = new MilestoneProgressionSQLService(context);
            completionHelper = new MilestoneCompletionHelper(context);
        }

        public bool CreateMilestoneProgession(MilestoneProgressionDTO milestone)
        {
            MilestoneProgression progression = new MilestoneProgression(milestone);
            return service.CreateMilestone(progression);
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

        public bool UpdateMilestoneProgression( MilestoneProgressionDTO milestone)
        {

            try
            {
                service.UpdateMilestoneProgression(new MilestoneProgression(milestone));
                completionHelper.IsMilestoneComplete(milestone.MilestoneId);
                return true;
            }
            catch (Exception)
            {

                return false;
            }

        }

        public List<MilestoneProgression> GetProjectProgressionWithUserId(UserDTO dto)
        {
            return service.GetProjectProgressionWithUserId(dto);
        }

        public List<MilestoneProgressionDTO> GetProgressionWithMilestoneId(MilestoneProgressionDTO dto)
        {
            completionHelper.IsMilestoneComplete(dto.MilestoneId);
            List<MilestoneProgression> progressions = service.GetProgressionWithMilestoneId(dto);
            List<MilestoneProgressionDTO> dtos = new List<MilestoneProgressionDTO>();

            if(progressions!=null)
            {
                foreach (var progression in progressions)
                {
                    MilestoneProgressionDTO progressiondto = new MilestoneProgressionDTO(progression);
                    dtos.Add(progressiondto);
                }
            }
            return dtos;
        }

        public List<ColleagueProgressionsDTO> GetColleagueProjectProgressionWithUserId(UserDTO dto)
        {
            return service.GetColleagueProjectProgressionWithUserId(dto);
        }
    }
}
