using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TIPP.Shared
{
    public class MilestoneDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int ActivityId { get; set; }
        public int UserId { get; set; }
        public decimal? Value { get; set; }
        public bool? Completed { get; set; }
        public MilestoneType Type { get; set; }

        public MilestoneDTO()
        {

        }

        public MilestoneDTO(Milestone milestone)
        {
            Id = milestone.Id;
            Name = milestone.Name;
            ActivityId = milestone.ActivityId;
            UserId = milestone.UserId;
            Value = milestone.Value;
            Completed = milestone.Completed;
            Type = milestone.Type;
        }
    }
}
