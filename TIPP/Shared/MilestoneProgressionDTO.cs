using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TIPP.Shared
{
    public class MilestoneProgressionDTO
    {
        public int Id { get; set; }
        public int MilestoneId { get; set; }
        public int ActivityID { get; set; }
        public decimal? Value { get; set; }
        public int Week { get; set; }

        public MilestoneProgressionDTO()
        {
        }

        public MilestoneProgressionDTO(int id)
        {
            Id = id;
        }

        public MilestoneProgressionDTO(MilestoneProgression milestoneProgression)
        {
            Id = milestoneProgression.Id;
            MilestoneId = milestoneProgression.MilestoneId;
            Value = milestoneProgression.Value;
            Week = milestoneProgression.Week;
        }

        public MilestoneProgressionDTO(int id, int milestoneId, decimal? value, int week)
        {
            Id = id;
            MilestoneId = milestoneId;
            Value = value;
            Week = week;
        }
    }
}
