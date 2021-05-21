using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TIPP.Server.Domain.DTOs;

namespace TIPP.Server.Repositories
{
    interface IProjectRepository
    {
        object GetProjects();
        bool CreateProject(ProjectDTO dto);
        ProjectDTO ReadProject(ProjectDTO dto);
        bool UpdateProject(ProjectDTO dto);
        bool DeleteProject(ProjectDTO dto);
    }
}
