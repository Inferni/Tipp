using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TIPP.Shared;

namespace TIPP.Client.Service
{
    public class MilestoneDataService : IMilestoneDataService
    {
        private IHttpService _httpService;
        private NavigationManager _navigationManager;

        public MilestoneDataService(IHttpService httpService, NavigationManager navigationManager)
        {
            _httpService = httpService;
            _navigationManager = navigationManager;
        }

        public async Task CreateMilestone(MilestoneDTO dto)
        {
            await _httpService.Post($"api/milestone", dto);
        }

        public async Task DeleteMilestone(MilestoneDTO dto)
        {
            await _httpService.Delete($"api/milestone/{dto.Id}");
        }

        public Task<object> GetAllMilstones()
        {
            throw new NotImplementedException();
        }

        public Task<Milestone> GetMilestone(MilestoneDTO dto)
        {
            throw new NotImplementedException();
        }

        public async Task<IList<Milestone>> GetMilestonesByActivityId(MilestoneDTO dto)
        {
            Console.WriteLine(dto.ActivityId);
            try
            {
                return await _httpService.Get<List<Milestone>>($"api/milestone/getbyactivityid/{dto.ActivityId}");

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
        }

        public Task UpdateMilestone(MilestoneDTO dto)
        {
            throw new NotImplementedException();
        }
    }
}
