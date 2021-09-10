using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TIPP.Shared
{
    public class MilestoneProgression
    {
        public int Id { get; set; }
        public int MilestoneId { get; set; }
        public decimal? Value { get; set; }
        public int Week { get; set; }
        [NotMapped]
        public Baseline Baseline { get; set; }

        public MilestoneProgression()
        {
        }

        public MilestoneProgression(MilestoneProgressionDTO milestoneProgressionDTO)
        {
            Id = milestoneProgressionDTO.Id;
            MilestoneId = milestoneProgressionDTO.MilestoneId;
            Value = milestoneProgressionDTO.Value;
            Week = milestoneProgressionDTO.Week;
        }

        public MilestoneProgression(int id, int milestoneId, decimal? value, int week)
        {
            Id = id;
            MilestoneId = milestoneId;
            Value = value;
            this.Week = week;
        }
    }
}
