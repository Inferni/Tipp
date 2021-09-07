﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TIPP.Shared
{
    public class ColleagueMilestoneDTO
    {
        public int MilestoneId { get; set; }
        public int UserID { get; set; }
        public string MilestoneName { get; set; }
        public string UserName { get; set; }

        public ColleagueMilestoneDTO()
        {
        }

        public ColleagueMilestoneDTO(int milestoneId, string milestoneName, string userName)
        {
            MilestoneId = milestoneId;
            MilestoneName = milestoneName;
            UserName = userName;
        }

        public ColleagueMilestoneDTO(int milestoneId, int userID, string milestoneName, string userName)
        {
            MilestoneId = milestoneId;
            UserID = userID;
            MilestoneName = milestoneName;
            UserName = userName;
        }
    }
}
