using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TIPP.Server.Domain;
using TIPP.Server.Domain.DTOs;
using TIPP.Shared;

namespace TIPP.Server.Services.SQLServices
{
    interface IProjectService
    {
        object GetProjects();
        bool CreateProject(Project project);
        ProjectDTO ReadProject(Project project);
        bool UpdateProject(Project project);
        bool DeleteProject(Project project);
    }
}
