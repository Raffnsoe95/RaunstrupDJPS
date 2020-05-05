using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Raunstrup.Contract.DTOs;
using Raunstrup.Contract.Services;

namespace Raunstrup.UI.Services
{
    public class WorkingHoursServiceProxy: IWorkingHoursService
    {

        private const string _workingHoursRequestUri = "api/WorkingHours";

        public WorkingHoursServiceProxy(HttpClient client)
        {
            Client = client;
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json")
                {
                    Parameters = { new NameValueHeaderValue("v", "1.0") }
                });
        }

        public HttpClient Client { get; }

        async Task IWorkingHoursService.AddAsync(WorkingHoursDto WorkingHours)
        {
            var json = JsonSerializer.Serialize(WorkingHours);
            var data = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await Client.PostAsync(_workingHoursRequestUri, data).ConfigureAwait(false);
            response.EnsureSuccessStatusCode();
        }

        async Task<WorkingHoursDto> IWorkingHoursService.GetWorkingHoursAsync(int id)
        {
            var response = await Client.GetAsync($"{_workingHoursRequestUri}/{id}").ConfigureAwait(false);

            response.EnsureSuccessStatusCode();

            var stream = await response.Content.ReadAsStreamAsync().ConfigureAwait(false);

            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };
            return await JsonSerializer.DeserializeAsync<WorkingHoursDto>(stream, options).ConfigureAwait(false);
        }

        async Task<IEnumerable<WorkingHoursDto>> IWorkingHoursService.GetWorkingHoursAsync()
        {
            var response = await Client.GetAsync(_workingHoursRequestUri).ConfigureAwait(false);
            response.EnsureSuccessStatusCode();

            var stream = await response.Content.ReadAsStreamAsync().ConfigureAwait(false);

            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };
            return await JsonSerializer.DeserializeAsync<IEnumerable<WorkingHoursDto>>(stream, options).ConfigureAwait(false);
        }

        async Task IWorkingHoursService.RemoveAsync(int id)
        {
            var response = await Client.DeleteAsync($"{_workingHoursRequestUri}/{id}").ConfigureAwait(false);
            response.EnsureSuccessStatusCode();
        }

        async Task IWorkingHoursService.UpdateAsync(int id, WorkingHoursDto workingHours)
        {
            var json = JsonSerializer.Serialize(workingHours);
            var data = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await Client.PutAsync($"{_workingHoursRequestUri}/{id}", data).ConfigureAwait(false);
            response.EnsureSuccessStatusCode();
        }
    }
}

