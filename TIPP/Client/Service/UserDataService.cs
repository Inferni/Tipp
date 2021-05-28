using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using TIPP.Client.Models;
using TIPP.Shared;

namespace TIPP.Client.Service
{
    public class UserDataService : IUserDataService, IUserDataServiceLogin
    {
        private IHttpService _httpService;
        private NavigationManager _navigationManager;
        private ILocalStorageService _localStorageService;
        private string _userKey = "user";

        public Models.User User { get; private set; }

        public UserDataService(
            IHttpService httpService,
            NavigationManager navigationManager,
            ILocalStorageService localStorageService
        )
        {
            _httpService = httpService;
            _navigationManager = navigationManager;
            _localStorageService = localStorageService;
        }

        public async Task Initialize()
        {
            User = await _localStorageService.GetItem<Models.User>(_userKey);
 
        }


        public async Task<ObjectResult> CreateUser(UserDTO dto)
        {
            object result;
            throw new NotImplementedException();
        }

        public Task<ObjectResult> DeleteUser(UserDTO dto)
        {
            throw new NotImplementedException();
        }

        public Task<object> GetAllUsers()
        {
            throw new NotImplementedException();
        }

        public Task<string> GetUser(UserDTO dto)
        {
            throw new NotImplementedException();
        }

        public async Task Login(Login model)
        {
            //User = await _httpService.Post<Models.User>("user/authenticate", model);
            //Console.WriteLine("User from backend: " + User.Username);
            //await _localStorageService.SetItem(_userKey, User);
            //Console.WriteLine("User set: " + _localStorageService.GetItem<Models.User>(_userKey));
            //await this.Initialize();
            //return User;

            User = await _httpService.Post<Models.User>("user/authenticate", model);
            await _localStorageService.SetItem(_userKey, User);

        }

        public async Task Logout()
        {
            User = null;
            await _localStorageService.RemoveItem(_userKey);
            _navigationManager.NavigateTo("user/login");
        }

        public Task<ObjectResult> UpdateUser(UserDTO dto)
        {
            throw new NotImplementedException();
        }
    }
}
