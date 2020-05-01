﻿using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Raunstrup.Contract.DTOs;
using Raunstrup.Contract.Services;

namespace Raunstrup.UI.Services
{
    public class EmployeeServiceProxy: IEmployeeservice
    {
        private const string _employeesRequestUri = "api/Employee";

        public EmployeeServiceProxy(HttpClient client)
        {
            Client = client;
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json")
                {
                    Parameters = { new NameValueHeaderValue("v", "1.1") }
                });
        }

        public HttpClient Client { get; }

        async Task IEmployeeservice.AddAsync(EmployeeDto employee)
        {
            var json = JsonSerializer.Serialize(employee);
            var data = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await Client.PostAsync(_employeesRequestUri, data).ConfigureAwait(false);
            response.EnsureSuccessStatusCode();
        }

        async Task<EmployeeDto> IEmployeeservice.GetEmployeesAsync(int id)
        {
            var response = await Client.GetAsync($"{_employeesRequestUri}/{id}").ConfigureAwait(false);

            response.EnsureSuccessStatusCode();

            var stream = await response.Content.ReadAsStreamAsync().ConfigureAwait(false);

            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };
            return await JsonSerializer.DeserializeAsync<EmployeeDto>(stream, options).ConfigureAwait(false);
        }

        async Task<IEnumerable<EmployeeDto>> IEmployeeservice.GetEmployeesAsync()
        {
            var response = await Client.GetAsync(_employeesRequestUri).ConfigureAwait(false);
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
            var response = await Client.DeleteAsync($"{_employeesRequestUri}/{id}").ConfigureAwait(false);
            response.EnsureSuccessStatusCode();
        }

        async Task IEmployeeservice.UpdateAsync(int id, EmployeeDto employee)
        {
            var json = JsonSerializer.Serialize(employee);
            var data = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await Client.PutAsync($"{_employeesRequestUri}/{id}", data).ConfigureAwait(false);
            response.EnsureSuccessStatusCode();
        }

    }
}
