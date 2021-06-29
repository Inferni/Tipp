using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TIPP.Shared;

namespace TIPP.Client.Service
{
    public class MilestoneProgressionService : IMilestoneProgressionService
    {
        private IHttpService _httpService;
        private NavigationManager _navigationManager;

        public MilestoneProgressionService(IHttpService httpService, NavigationManager navigationManager)
        {
            _httpService = httpService;
            _navigationManager = navigationManager;
        }

        public Task CreateMilestoneProgression(MilestoneProgressionDTO dto)
        {
            throw new NotImplementedException();
        }

        public Task DeleteMilestoneProgression(MilestoneProgressionDTO dto)
        {
            throw new NotImplementedException();
        }

        public Task<IList<MilestoneProgression>> GetAllMilestoneProgressionssByUserId(UserDTO dto)
        {
            throw new NotImplementedException();
        }

        public Task<object> GetAllProjects()
        {
            throw new NotImplementedException();
        }

        public Task<MilestoneProgression> GetMilestoneProgression(MilestoneProgressionDTO dto)
        {
            throw new NotImplementedException();
        }

        public Task UpdateMilestoneProgression(MilestoneProgressionDTO dto)
        {
            throw new NotImplementedException();
        }

        public async Task<IList<MilestoneProgression>> GetProgressionWithUser(UserDTO dto)
        {
            Console.WriteLine($"d{dto.Id} {dto.ProjectID}");
            return await _httpService.Get<IList<MilestoneProgression>>($"api/milestone/progression/getprogressionwithuser/{dto.Id}/{dto.ProjectID}");
        }

        public async Task<IList<MilestoneProgression>> GetProgressionWithMilestoneId(int milestoneid)
        {
            return await _httpService.Get<IList<MilestoneProgression>>($"api/milestone/progression/GetByMilestoneId/{milestoneid}");
        }
    }
}
