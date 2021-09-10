using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TIPP.Shared
{
    public class Baseline
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int ProjectId { get; set; }
        public int WeekNumber { get; set; }
        public float BaselineValue { get; set; }

        public Baseline()
        {
        }
    }
}
