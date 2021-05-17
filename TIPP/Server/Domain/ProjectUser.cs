using System;
using System.Collections.Generic;

#nullable disable

namespace TIPP.Server.Domain
{
    public partial class ProjectUser
    {
        public int Project { get; set; }
        public int User { get; set; }

        public virtual Project ProjectNavigation { get; set; }
        public virtual User UserNavigation { get; set; }
    }
}
