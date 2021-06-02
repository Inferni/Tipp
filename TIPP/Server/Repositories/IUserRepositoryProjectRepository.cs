using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TIPP.Shared;

namespace TIPP.Server.Repositories
{
    interface IUserRepositoryProjectRepository
    {
        User GetUserById(UserDTO dto);
    }
}
