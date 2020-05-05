//using Raunstrup.Contract.DTOs;
using Raunstrup.Contract.DTOs;
using Raunstrup.DataAccess.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Raunstrup.Api.Models
{
    public class ItemMapper
    {
        public static Item Map(ItemDto dto)
        {
            if (dto == null)
            {
                return null;
            }

            return new Item
            { Id = dto.Id, Name = dto.Name, Price = dto.Price, Active = dto.Active, RowVision = dto.RowVision };
        }

        public static IEnumerable<ItemDto> Map(IEnumerable<Item> model)
        {
            return model.Select(x => Map(x)).AsEnumerable();
        }

        public static ItemDto Map(Item model)
        {
            return new ItemDto
            { Id = model.Id, Name = model.Name, Price = model.Price, Active = model.Active, RowVision = model.RowVision };
        }
    }
}
