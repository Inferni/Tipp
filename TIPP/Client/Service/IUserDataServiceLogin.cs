using System.Threading.Tasks;

namespace TIPP.Client.Service
{
    interface IUserDataServiceLogin
    {
        Task<TIPP.Shared.User> Login(Models.Login model);
        Task Logout();
    }
}
