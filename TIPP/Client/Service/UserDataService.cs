using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using TIPP.Shared;

namespace TIPP.Client.Service
{
    public class UserDataService : IUserDataService
    {
        private readonly HttpClient httpClient;

        public UserDataService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }
        
        public async Task<ObjectResult> CreateUser(UserDTO dto)
        {
            object result;
            result = httpClient.GetStreamAsync("api/usercontroller");
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

        public Task<ObjectResult> UpdateUser(UserDTO dto)
        {
            throw new NotImplementedException();
        }
    }
}
