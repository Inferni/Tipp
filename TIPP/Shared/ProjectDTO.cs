using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TIPP.Shared
{
    public class ProjectDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool Completed { get; set; }

        public virtual ICollection<Activity> Activities { get; set; }

        public ProjectDTO()
        {
            Activities = new HashSet<Activity>();
        }

        public ProjectDTO(Project project)
        {
            Id = project.Id;
            Name = project.Name;
            Completed = project.Completed;
            Activities = project.Activities;
        }

        public ProjectDTO(int id, string name, bool completed, ICollection<Activity> activities)
        {
            Id = id;
            Name = name;
            Completed = completed;
            Activities = activities;
        }
    }
}
