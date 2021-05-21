using TIPP.Shared;

namespace TIPP.Server.Repositories
{
    interface IUserRepository
    {
        object GetUsers();
        bool CreateUser(UserDTO dto);
        UserDTO ReadUser(UserDTO dto);
        bool UpdateUser(UserDTO dto);
        bool DeleteUser(UserDTO dto);

    }
}
