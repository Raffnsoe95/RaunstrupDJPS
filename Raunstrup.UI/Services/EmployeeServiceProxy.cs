using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Raunstrup.Contract.DTOs;
using Raunstrup.Contract.Services;
using Raunstrup.UI.Models;

namespace Raunstrup.UI.Services
{
    public class EmployeeServiceProxy : IEmployeeservice
    {
        private const string _employeeRequestUri = "api/Employee";
        private IProjectService projectService;
        public EmployeeServiceProxy(HttpClient client, IProjectService projectService)
        {
            this.projectService = projectService;
            Client = client;
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json")
                {
                    Parameters = { new NameValueHeaderValue("v", "1.0") }
                });
        }

        public HttpClient Client { get; }

        async Task IEmployeeservice.AddAsync(EmployeeDto employee)
        {
            var json = JsonSerializer.Serialize(employee);
            var data = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await Client.PostAsync(_employeeRequestUri, data).ConfigureAwait(false);
            response.EnsureSuccessStatusCode();
        }

        async Task<EmployeeDto> IEmployeeservice.GetEmployeeAsync(int id)
        {
            var response = await Client.GetAsync($"{_employeeRequestUri}/{id}").ConfigureAwait(false);

            response.EnsureSuccessStatusCode();

            var stream = await response.Content.ReadAsStreamAsync().ConfigureAwait(false);

            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };
            return await JsonSerializer.DeserializeAsync<EmployeeDto>(stream, options).ConfigureAwait(false);
        }

        public async Task<IEnumerable<EmployeeDto>> GetEmployeeAsync()
        {
            var response = await Client.GetAsync(_employeeRequestUri).ConfigureAwait(false);
            response.EnsureSuccessStatusCode();

            var stream = await response.Content.ReadAsStreamAsync().ConfigureAwait(false);

            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };
            return await JsonSerializer.DeserializeAsync<IEnumerable<EmployeeDto>>(stream, options).ConfigureAwait(false);
        }

        async Task IEmployeeservice.RemoveAsync(int id)
        {
            var response = await Client.DeleteAsync($"{_employeeRequestUri}/{id}").ConfigureAwait(false);
            response.EnsureSuccessStatusCode();
        }

        async Task IEmployeeservice.UpdateAsync(int id, EmployeeDto employee)
        {
            var json = JsonSerializer.Serialize(employee);
            var data = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await Client.PutAsync($"{_employeeRequestUri}/{id}", data).ConfigureAwait(false);
            response.EnsureSuccessStatusCode();
        }
        async Task IEmployeeservice.AddAsync(int id, int projectid)
        {
            var projectEmployee = new ProjectEmployeeDto { Id = id, ProjectId = projectid };
            var json = JsonSerializer.Serialize(projectEmployee);
            var data = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await Client.PostAsync(_employeeRequestUri + "/AddProjectEmployeeToProject", data).ConfigureAwait(false);
            response.EnsureSuccessStatusCode();
        }
        async Task IEmployeeservice.AddAsync(ProjectDrivingDto projectDriving)
        {
            var json = JsonSerializer.Serialize(projectDriving);
            var data = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await Client.PostAsync(_employeeRequestUri + "/AddProjectDrivingToProject", data).ConfigureAwait(false);
            response.EnsureSuccessStatusCode();
        }


        public async Task<IEnumerable<EmployeeDto>> GetFilteredEmployeesAsync(string searchString)
        {
            var response = await Client.GetAsync(_employeeRequestUri + $"/search/{searchString}").ConfigureAwait(false);
            response.EnsureSuccessStatusCode();

            var stream = await response.Content.ReadAsStreamAsync().ConfigureAwait(false);

            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };
            return await JsonSerializer.DeserializeAsync<IEnumerable<EmployeeDto>>(stream, options).ConfigureAwait(false);
        }
        async Task IEmployeeservice.AddProjectEmployeeAsync(List<ProjectEmployeeDto> items)
        {
            foreach (var projectEmployee in items)
            {
                var json = JsonSerializer.Serialize(projectEmployee);
                var data = new StringContent(json, Encoding.UTF8, "application/json");
                var response = await Client.PostAsync(_employeeRequestUri + "/AddProjectEmployeeToProject", data).ConfigureAwait(false);
                response.EnsureSuccessStatusCode();
            }
        }

        public async Task<IEnumerable<EmployeeDto>> GetChosenEmployees(string searchString)
        {
            if (!String.IsNullOrEmpty(searchString))
            {
                var employeeDtos = await GetFilteredEmployeesAsync(searchString).ConfigureAwait(false);
                return employeeDtos;
            }
            else
            {
                var employeeDtos = await GetEmployeeAsync().ConfigureAwait(false);
                return employeeDtos;
            }
        }
    }
}
