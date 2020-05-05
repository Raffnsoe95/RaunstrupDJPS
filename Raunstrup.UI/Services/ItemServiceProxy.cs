using Raunstrup.Contract.DTOs;
using Raunstrup.Contract.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Raunstrup.UI.Services
{
    public class ItemServiceProxy :IItemService
    {
        private const string _itemsRequestUri = "api/Items";

        public ItemServiceProxy(HttpClient client)
        {
            Client = client;
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json")
            {
                    Parameters = { new NameValueHeaderValue("v", "1.0") }
            });
        }

        public HttpClient Client { get; }

        async Task IItemService.AddAsync(ItemDto item)
        {
            var json = JsonSerializer.Serialize(item);
            var data = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await Client.PostAsync(_itemsRequestUri, data).ConfigureAwait(false);
            response.EnsureSuccessStatusCode();
        }

        async Task<ItemDto> IItemService.GetItemAsync(int id)
        {
            var response = await Client.GetAsync($"{_itemsRequestUri}/{id}").ConfigureAwait(false);

            response.EnsureSuccessStatusCode();

            var stream = await response.Content.ReadAsStreamAsync().ConfigureAwait(false);

            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };
            return await JsonSerializer.DeserializeAsync<ItemDto>(stream, options).ConfigureAwait(false);
        }

        async Task<IEnumerable<ItemDto>> IItemService.GetItemsAsync()
        {
            var response = await Client.GetAsync(_itemsRequestUri).ConfigureAwait(false);
            response.EnsureSuccessStatusCode();

            var stream = await response.Content.ReadAsStreamAsync().ConfigureAwait(false);

            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };
            return await JsonSerializer.DeserializeAsync<IEnumerable<ItemDto>>(stream, options).ConfigureAwait(false);
        }

        async Task IItemService.RemoveAsync(int id)
        {
            var response = await Client.DeleteAsync($"{_itemsRequestUri}/{id}").ConfigureAwait(false);
            response.EnsureSuccessStatusCode();
        }

        async Task IItemService.UpdateAsync(int id, ItemDto item)
        {
            var json = JsonSerializer.Serialize(item);
            var data = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await Client.PutAsync($"{_itemsRequestUri}/{id}", data).ConfigureAwait(false);
            response.EnsureSuccessStatusCode();
        }

        async Task IItemService.AddAsync(int id, int projectid)
        {
            var projectItem = new ProjectItemDto { Id = id, ProjectId = projectid };
            var json = JsonSerializer.Serialize(projectItem);
            var data = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await Client.PostAsync(_itemsRequestUri + "/AddProjectItemToProject", data).ConfigureAwait(false);
            response.EnsureSuccessStatusCode();
        }
    }
}
