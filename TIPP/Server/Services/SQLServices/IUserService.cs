﻿using TIPP.Shared;

namespace TIPP.Server.Services.SQLServices
{
    interface IUserService
    {
        object GetUsers();
        object GetUsersByProjectId(ProjectDTO dto);
        User Authenticate(User dto);
        bool CreateUser(User user);
        UserDTO ReadUser(User user);
        bool UpdateUser(User user);
        bool DeleteUser(User user);
    }
}
