using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Raunstrup.Contract;
using Raunstrup.Contract.Services;
using Raunstrup.Contract.DTOs;
using Microsoft.AspNetCore.Authorization;



namespace Raunstrup.UI.Services
{
    public class ProjectServiceProxy: IProjectService
    {
        private const string _projectRequestUri = "api/Project";

        public ProjectServiceProxy(HttpClient client)
        {
            Client = client;
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json")
                {
                    Parameters = { new NameValueHeaderValue("v", "1.0") }
                });
        }

        public HttpClient Client { get; }

        async Task IProjectService.AddAsync(ProjectDto project)
        {
            var json = JsonSerializer.Serialize(project);
            var data = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await Client.PostAsync(_projectRequestUri, data).ConfigureAwait(false);
            response.EnsureSuccessStatusCode();
        }

     
        async Task<ProjectDto> IProjectService.GetProjectAsync(int id)
        {
            var response = await Client.GetAsync($"{_projectRequestUri}/{id}").ConfigureAwait(false);

            response.EnsureSuccessStatusCode();

            var stream = await response.Content.ReadAsStreamAsync().ConfigureAwait(false);

            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };
            return await JsonSerializer.DeserializeAsync<ProjectDto>(stream, options).ConfigureAwait(false);
        }

        async Task<IEnumerable<ProjectDto>> IProjectService.GetProjectAsync(string userName, string userRole)
        {
            string requestUri = _projectRequestUri;
            if (userRole == "User")
            {
                requestUri += $"/GetAllByEmployeeId/{userName}";
            }

            var response = await Client.GetAsync(requestUri).ConfigureAwait(false);
            response.EnsureSuccessStatusCode();

            var stream = await response.Content.ReadAsStreamAsync().ConfigureAwait(false);

            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };
            return await JsonSerializer.DeserializeAsync<IEnumerable<ProjectDto>>(stream, options).ConfigureAwait(false);
        }

        async Task IProjectService.RemoveAsync(int id)
        {
            var response = await Client.DeleteAsync($"{_projectRequestUri}/{id}").ConfigureAwait(false);
            response.EnsureSuccessStatusCode();
        }

        async Task IProjectService.UpdateAsync(int id, ProjectDto project)
        {
            var json = JsonSerializer.Serialize(project);
            var data = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await Client.PutAsync($"{_projectRequestUri}/{id}", data).ConfigureAwait(false);
            response.EnsureSuccessStatusCode();
        }

       async Task<IEnumerable<ProjectDto>> IProjectService.GetProjectsByCustomerId(int customerId)
        {

            var response = await Client.GetAsync(_projectRequestUri + $"/GetProjectsByCustomerId/{customerId}").ConfigureAwait(false);
            response.EnsureSuccessStatusCode();

            var stream = await response.Content.ReadAsStreamAsync().ConfigureAwait(false);

            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };
            return await JsonSerializer.DeserializeAsync<IEnumerable<ProjectDto>>(stream, options).ConfigureAwait(false);
        }
        async Task<IEnumerable<ProjectDto>> IProjectService.GetProjectsByEmployeeId(int employeeId)
        {

            var response = await Client.GetAsync(_projectRequestUri + $"/GetProjectsByEmployeeId/{employeeId}").ConfigureAwait(false);
            response.EnsureSuccessStatusCode();

            var stream = await response.Content.ReadAsStreamAsync().ConfigureAwait(false);

            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };
            return await JsonSerializer.DeserializeAsync<IEnumerable<ProjectDto>>(stream, options).ConfigureAwait(false);
        }

    }
}

