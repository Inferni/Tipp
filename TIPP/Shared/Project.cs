using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TIPP.Shared
{
    class Project
    {
        

        public int Id { get; set; }
        public string Name { get; set; }
        public bool Completed { get; set; }

        public virtual ICollection<Activity> Activities { get; set; }

        public Project()
        {
            Activities = new HashSet<Activity>();
        }

        public Project(ProjectDTO dto)
        {
            Activities = new HashSet<Activity>();

            Id = dto.Id;
            Name = dto.Name;
            Completed = dto.Completed;
            Activities = dto.Activities;
        }
    }
}
