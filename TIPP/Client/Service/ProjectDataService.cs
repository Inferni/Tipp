using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TIPP.Shared;

namespace TIPP.Client.Service
{
    public class ProjectDataService : IProjectDataService
    {
        private IHttpService _httpService;
        private NavigationManager _navigationManager;

        public ProjectDataService(IHttpService httpService, NavigationManager navigationManager)
        {
            _httpService = httpService;
            _navigationManager = navigationManager;
        }

        public Project Project { get; private set; }

        public Task<ObjectResult> CreateProject(ProjectDTO dto)
        {
            throw new NotImplementedException();
        }

        public Task<ObjectResult> DeleteProject(ProjectDTO dto)
        {
            throw new NotImplementedException();
        }

        public Task<object> GetAllProjects()
        {
            throw new NotImplementedException();
        }

        public async Task<IList<TIPP.Shared.Project>> GetAllProjectsByUserId(UserDTO dto)
        {
           
            IList<Project> users = await _httpService.Get<IList<Project>>("api/project/getbyuser/{dto.id}");
            Console.WriteLine(users);
            return users;
        }

        public Task<string> GetProject(ProjectDTO dto)
        {
            throw new NotImplementedException();
        }

        public Task Initialize()
        {
            throw new NotImplementedException();
        }

        public Task<ObjectResult> UpdateProject(ProjectDTO dto)
        {
            throw new NotImplementedException();
        }
    }
}
