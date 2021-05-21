using TIPP.Shared;

namespace TIPP.Server.Services.SQLServices
{
    interface IUserService
    {
        object GetUsers();
        bool CreateUser(User user);
        UserDTO ReadUser(User user);
        bool UpdateUser(User user);
        bool DeleteUser(User user);
    }
}
