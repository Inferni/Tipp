using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TIPP.Shared
{
    public class ColleagueProgressionsDTO
    {
        public User Colleague { get; set; }
        public List<MilestoneProgression> Progressions { get; set; }

        public ColleagueProgressionsDTO()
        {
        }

        public ColleagueProgressionsDTO(User colleague, List<MilestoneProgression> progressions)
        {
            Colleague = colleague;
            Progressions = progressions;
        }
    }
}
