using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using TIPP.Shared;

#nullable disable

namespace TIPP.Server.Domain
{
    public partial class ProjectUser
    {
        public int Id { get; set; }

        public int Project { get; set; }
        public int User { get; set; }

        public virtual Project ProjectNavigation { get; set; }
        public virtual User UserNavigation { get; set; }
    }
}
