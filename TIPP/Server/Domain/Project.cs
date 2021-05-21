using System;
using System.Collections.Generic;
using TIPP.Server.Domain.DTOs;

#nullable disable

namespace TIPP.Server.Domain
{
    public partial class Project
    {
        public Project(ProjectDTO dto)
        {
            Activities = new HashSet<Activity>();

            Id = dto.Id;
            Name = dto.Name;
            Completed = dto.Completed;
            Activities = dto.Activities;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public bool Completed { get; set; }

        public virtual ICollection<Activity> Activities { get; set; }
    }
}
