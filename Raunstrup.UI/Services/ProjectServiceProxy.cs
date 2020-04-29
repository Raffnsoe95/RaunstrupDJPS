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



namespace Raunstrup.UI.Services
{
    public class ProjectServiceProxy: IProjectService
    {
        private const string _customerRequestUri = "api/Customers";

        public ProjectServiceProxy(HttpClient client)
        {
            Client = client;
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json")
                {
                    Parameters = { new NameValueHeaderValue("v", "1.1") }
                });
        }

        public HttpClient Client { get; }

        async Task IProjectService.AddAsync(ProjectDto project)
        {
            var json = JsonSerializer.Serialize(project);
            var data = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await Client.PostAsync(_customerRequestUri, data).ConfigureAwait(false);
            response.EnsureSuccessStatusCode();
        }

        async Task<ProjectDto> IProjectService.GetProjectAsync(int id)
        {
            var response = await Client.GetAsync($"{_customerRequestUri}/{id}").ConfigureAwait(false);

            response.EnsureSuccessStatusCode();

            var stream = await response.Content.ReadAsStreamAsync().ConfigureAwait(false);

            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };
            return await JsonSerializer.DeserializeAsync<ProjectDto>(stream, options).ConfigureAwait(false);
        }

        async Task<IEnumerable<ProjectDto>> IProjectService.GetProjectAsync()
        {
            var response = await Client.GetAsync(_customerRequestUri).ConfigureAwait(false);
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
            var response = await Client.DeleteAsync($"{_customerRequestUri}/{id}").ConfigureAwait(false);
            response.EnsureSuccessStatusCode();
        }

        async Task IProjectService.UpdateAsync(int id, ProjectDto project)
        {
            var json = JsonSerializer.Serialize(project);
            var data = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await Client.PutAsync($"{_customerRequestUri}/{id}", data).ConfigureAwait(false);
            response.EnsureSuccessStatusCode();
        }
    }
}

