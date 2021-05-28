using System.Threading.Tasks;

namespace TIPP.Client.Service
{
    interface IUserDataServiceLogin
    {
        Task Login(Models.Login model);
        Task Logout();
    }
}
