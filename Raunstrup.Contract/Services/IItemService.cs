using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Text;
using Raunstrup.Contract.DTOs;

namespace Raunstrup.Contract.Services
{
    public interface IItemService
    {
        Task<IEnumerable<ItemDto>> GetItemsAsync();

        Task<ItemDto> GetItemAsync(int id);

        Task AddAsync(ItemDto item);

        Task UpdateAsync(int id, ItemDto item);

        Task RemoveAsync(int id);

        Task AddAssignedItemAsync(List<ProjectAssignedItemDto> items);

        Task AddUsedItemAsync(List<ProjectUsedItemDto> items);

        Task<IEnumerable<ItemDto>> GetFilteredItemsAsync(string searchString);
    }
}
