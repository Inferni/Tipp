using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TIPP.Server.Domain;
using TIPP.Server.Services.SQLServices;
using TIPP.Shared;

namespace TIPP.Server.Helpers
{
    public class MilestoneCompletionHelper
    {
        private IMilestoneProgressionService progressionService;
        private IMileStoneService milestoneService;

        public MilestoneCompletionHelper(tipp_DBContext context)
        {
            this.progressionService = new MilestoneProgressionSQLService(context);
            milestoneService = new MilestoneSQLService(context);
        }

        public bool IsMilestoneComplete(int milestoneId)
        {
            MilestoneProgressionDTO progressionDTO = new MilestoneProgressionDTO();
            progressionDTO.MilestoneId = milestoneId;
            List<MilestoneProgression> progressions = progressionService.GetProgressionWithMilestoneId(progressionDTO);

            int value = 0;
            foreach (var progression in progressions)
            {
                value += Convert.ToInt32(progression.Value);
            }
            MilestoneDTO milestoneDTO = new MilestoneDTO();
            milestoneDTO.Id = milestoneId;
            Milestone milestone = milestoneService.GetMilestoneById(milestoneDTO);

            if(milestone.Value <= value)
            {
                //MILESTONE COMPLETED
                milestone.Completed = true;
                return milestoneService.UpdateMilestone(milestone);        
            }
            else
            {
                //MILESTONE NOT COMPLETED
                return false;
            }

        }
    }
}
