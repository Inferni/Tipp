using System;
using System.Collections.Generic;

#nullable disable

namespace TIPP.Server.Domain
{
    public partial class Milestone
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int ActivityId { get; set; }
        public int UserId { get; set; }
        public decimal? Value { get; set; }
        public decimal? TimeSpent { get; set; }
    }
}
