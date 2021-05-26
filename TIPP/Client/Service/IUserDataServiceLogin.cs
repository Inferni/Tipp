using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TIPP.Client.Service
{
    interface IUserDataServiceLogin
    {
        Task<Models.User> Login(Models.Login model);
    }
}
