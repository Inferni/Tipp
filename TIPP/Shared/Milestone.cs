using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TIPP.Shared
{
     public  class Milestone
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int ActivityId { get; set; }
        public int UserId { get; set; }
        public decimal? Value { get; set; }
        public decimal? TimeSpent { get; set; }

        public Milestone()
        {
        }

        public Milestone(MilestoneDTO dto)
        {
            Id = dto.Id;
            Name = dto.Name;
            ActivityId = dto.ActivityId;
            UserId = dto.UserId;
            Value = dto.Value;
            TimeSpent = dto.TimeSpent;
        }

        public Milestone(int id, string name, int activityId, int userId, decimal? value, decimal? timeSpent)
        {
            Id = id;
            Name = name;
            ActivityId = activityId;
            UserId = userId;
            Value = value;
            TimeSpent = timeSpent;
        }
    }
}
