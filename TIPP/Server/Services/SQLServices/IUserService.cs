using TIPP.Shared;

namespace TIPP.Server.Services.SQLServices
{
    interface IUserService
    {
        object GetUsers();

        User Authenticate(User dto);
        bool CreateUser(User user);
        UserDTO ReadUser(User user);
        bool UpdateUser(User user);
        bool DeleteUser(User user);
    }
}
