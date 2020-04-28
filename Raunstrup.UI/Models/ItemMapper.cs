using Raunstrup.Contract.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Raunstrup.UI.Models
{
    public class ItemMapper
    {
        public static ItemViewModel Map(ItemDto dto)
        {
            return new ItemViewModel
            { Id = dto.Id, Name = dto.Name, Price = dto.Price, Active = dto.Active };
        }

        public static IEnumerable<ItemViewModel> Map(IEnumerable<ItemDto> dtos)
        {
            return dtos.Select(x => Map(x)).AsEnumerable();
        }

        public static ItemDto Map(ItemViewModel view)
        {
            return new ItemDto
            { Id = view.Id, Name = view.Name, Price = view.Price, Active = view.Active };
        }
    }
}
