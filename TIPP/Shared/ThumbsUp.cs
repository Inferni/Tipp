using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TIPP.Shared
{
    public class ThumbsUp
    {
        public int Id { get; set; }
        public int MilestoneId { get; set; }
        public int UserId { get; set; }
        public bool Seen { get; set; }

        public string Username { get; set; }
        public string MilestoneName { get; set; }

        public ThumbsUp()
        {
        }

        public ThumbsUp(int id, int milestoneId, int userId, bool seen, string username, string milestoneName)
        {
            Id = id;
            MilestoneId = milestoneId;
            UserId = userId;
            Seen = seen;
            Username = username;
            MilestoneName = milestoneName;
        }

        public ThumbsUp(ThumbsUpDTO dto)
        {
            Id = dto.Id;
            MilestoneId = dto.MilestoneId;
            UserId = dto.UserId;
            Seen = dto.Seen;
            Username = dto.UserName;
            MilestoneName = dto.MilestoneName;
        }
    }
}
