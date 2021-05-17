using System;
using System.Collections.Generic;

#nullable disable

namespace TIPP.Server.Domain
{
    public partial class Project
    {
        public Project()
        {
            Activities = new HashSet<Activity>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public bool Completed { get; set; }

        public virtual ICollection<Activity> Activities { get; set; }
    }
}
