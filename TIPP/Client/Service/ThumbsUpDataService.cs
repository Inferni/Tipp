using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TIPP.Shared;

namespace TIPP.Client.Service
{
    public class ThumbsUpDataService : IThumbsUpDataService
    {
        private IHttpService _httpService;
        private NavigationManager _navigationManager;

        public ThumbsUpDataService(IHttpService httpService, NavigationManager navigationManager)
        {
            _httpService = httpService;
            _navigationManager = navigationManager;
        }

        public async Task CreateThumbsUp(ThumbsUpDTO dto)
        {
            try
            {
                await _httpService.Post($"api/thumbsup", dto);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex);
            }
                
        }

        public Task DeleteThumbsUp(ThumbsUpDTO dto)
        {
            throw new NotImplementedException();
        }

        public Task<object> GetAllThumbsUps()
        {
            throw new NotImplementedException();
        }

        public Task<ThumbsUp> GetThumbsUp(ThumbsUpDTO dto)
        {
            throw new NotImplementedException();
        }

        public async Task<IList<ThumbsUp>> GetThumbsUpsByProjectAndUserId(int projectid, int userid)
        {
            return await _httpService.Get<IList<ThumbsUp>>($"api/thumbsup/GetThumbsUpsByProjectAndUserId/{projectid}/{userid}");
        }

        public async Task UpdateThumbsUp(ThumbsUpDTO dto)
        {
            await _httpService.Put($"api/thumbsup/{dto.Id}", dto);
        }
    }
}
