using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
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
            try
            {
                User = await _localStorageService.GetItem<Models.User>(_userKey);

            }
            catch (Exception)
            {
                User = null;
                await _localStorageService.RemoveItem(_userKey);
            }
        }

        public async Task<ObjectResult> CreateUser(UserDTO dto)
        {
            object result;
            throw new NotImplementedException();
        }

        public async Task AddUserToProject(UserDTO dto)
        {
            await _httpService.Post("api/user/addtoproject", dto);
        }

        public async Task DeleteUser(UserDTO dto)
        {
            await _httpService.Delete($"api/user/{dto.Id}");
        }

        public async Task RemoveUserFromProject(UserDTO dto)
        {
            await _httpService.DeleteItem($"api/user/removefromproject", dto);

        }

        public Task<object> GetAllUsers()
        {
            throw new NotImplementedException();
        }

        public Task<string> GetUser(UserDTO dto)
        {
            throw new NotImplementedException();
        }

        public async Task<Models.User> Login(Login model)
        {
            User = await _httpService.Post<Models.User>("api/user/authenticate", model);
            await _localStorageService.SetItem(_userKey, User);
            return User;
        }

        public Task<ObjectResult> UpdateUser(UserDTO dto)
        {
            throw new NotImplementedException();
        }

        public async Task Logout()
        {
            User = null;
            await _localStorageService.RemoveItem(_userKey);
            _navigationManager.NavigateTo("account/login");
        }

        public async Task<IList<Models.User>> GetAllUsersByProjectId(ProjectDTO dto)
        {
            IList<Models.User> users = await _httpService.Get<IList<Models.User>>("api/user/getbyproject/{dto.id}");
            Console.WriteLine(users);
            return users;
        }
    }
}
