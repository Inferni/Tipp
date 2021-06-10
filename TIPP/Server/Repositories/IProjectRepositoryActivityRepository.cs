using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TIPP.Shared;

namespace TIPP.Server.Repositories
{
    interface IProjectRepositoryActivityRepository
    {
        Project GetProjectById(int id);
    }
}
