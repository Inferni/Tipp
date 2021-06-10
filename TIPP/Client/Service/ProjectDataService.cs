using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TIPP.Client.Models;
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

        public async Task CreateProject(AddProject dto)
        {
            await _httpService.Post("api/project", dto);

        }

        public async Task DeleteProject(ProjectDTO dto)
        {
            await _httpService.Delete($"api/project/{dto.Id}");
        }

        public Task<object> GetAllProjects()
        {
            throw new NotImplementedException();
        }

        public async Task<IList<TIPP.Shared.Project>> GetAllProjectsByUserId(UserDTO dto)
        {
            IList<Project> projects = await _httpService.Get<IList<Project>>($"api/project/getbyuser/{dto.Id}");
            Console.WriteLine(projects);
            return projects;
        }

        public async Task<IList<TIPP.Shared.User>> GetUsersByProjectId(ProjectDTO dto)
        {
            return await _httpService.Get<IList<TIPP.Shared.User>>($"api/project/getusersbyprojectid/{dto.Id}");
        }

        public async Task<Project> GetProject(ProjectDTO dto)
        {
            return await _httpService.Get<Project>($"api/project/{dto.Id}");
        }

        public Task Initialize()
        {
            throw new NotImplementedException();
        }

        public async Task UpdateProject(ProjectDTO dto)
        {
            await _httpService.Put($"api/project/{dto.Id}", dto);
        }
    }
}
