using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TIPP.Shared
{
    public class ThumbsUpDTO
    {
        public int Id { get; set; }
        public int MilestoneId { get; set; }
        public int UserId { get; set; }
        public bool Seen { get; set; }

        public string UserName { get; set; }
        public string MilestoneName { get; set; }

        public ThumbsUpDTO()
        {
        }

        public ThumbsUpDTO(ThumbsUp thumbsUp)
        {
            Id = thumbsUp.Id;
            MilestoneId = thumbsUp.MilestoneId;
            UserId = thumbsUp.UserId;
            Seen = thumbsUp.Seen;
            UserName = thumbsUp.Username;
            MilestoneName = thumbsUp.MilestoneName;
        }

        public ThumbsUpDTO(int id, int milestoneId, int userId, bool seen, string userName, string milestoneName)
        {
            Id = id;
            MilestoneId = milestoneId;
            UserId = userId;
            Seen = seen;
            UserName = userName;
            MilestoneName = milestoneName;
        }
    }
}
