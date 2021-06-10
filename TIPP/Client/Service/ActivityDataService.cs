using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TIPP.Shared;

namespace TIPP.Client.Service
{
    public class ActivityDataService : IActivityDataService
    {
        private IHttpService _httpService;
        private NavigationManager _navigationManager;

        public ActivityDataService(IHttpService httpService, NavigationManager navigationManager)
        {
            _httpService = httpService;
            _navigationManager = navigationManager;
        }

        public async Task CreateActivity(ActivityDTO dto)
        {
            await _httpService.Post($"api/activity", dto);
        }

        public async Task DeleteActivity(ActivityDTO dto)
        {
            await _httpService.Delete($"api/activity/{dto.Id}");
        }

        public async Task<IList<Activity>> GetActivitiesByProjectId(ActivityDTO dto)
        {
            return await _httpService.Get<IList<Activity>>($"api/activity/getbyprojectid/{dto.ProjectId}");
        }

        public Task<Activity> GetActivity(ActivityDTO dto)
        {
            throw new NotImplementedException();
        }

        public Task<object> GetAllActivities()
        {
            throw new NotImplementedException();
        }


        public Task UpdateActivity(ActivityDTO dto)
        {
            throw new NotImplementedException();
        }
    }
}
