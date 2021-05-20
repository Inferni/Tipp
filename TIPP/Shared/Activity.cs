using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TIPP.Shared
{
    public class Activity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int ProjectId { get; set; }

        public virtual Project Project { get; set; }

        public Activity()
        {
        }

        public Activity(ActivityDTO dto)
        {
            Id = dto.Id;
            Name = dto.Name;
            ProjectId = dto.ProjectId;
        }

        public Activity(int id, string name, int projectId, Project project)
        {
            Id = id;
            Name = name;
            ProjectId = projectId;
            Project = project;
        }
    }
}
