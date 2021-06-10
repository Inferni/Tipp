using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TIPP.Shared
{
    public class ActivityDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int ProjectId { get; set; }

        public virtual Project Project { get; set; }

        public ActivityDTO()
        {
        }

        public ActivityDTO(int projectId)
        {
            ProjectId = projectId;
        }

        public ActivityDTO(Activity activity)
        {
            Id = activity.Id;
            Name = activity.Name;
            ProjectId = activity.ProjectId;

        }
    }
}
