using Raunstrup.Contract;
using Raunstrup.Contract.DTOs;
using Raunstrup.DataAccess;
using Raunstrup.DataAccess.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Raunstrup.Api.Models
{
    public class ItemDiscountTypeMapper
    {
        public static ItemDiscountType Map(ItemDiscountTypeDto dto)
        {
            if (dto == null)
            { return null; }

            return new ItemDiscountType
            {
                Id = dto.DiscountId,
                DiscountPercentage = dto.DiscountPercentage,
                StartDate = dto.StartDate,
                EndDate = dto.EndDate,
                Amount = dto.Amount
            };
        }

        public static IEnumerable<ItemDiscountTypeDto> Map(IEnumerable<ItemDiscountType> model)
        {
            return model.Select(x => Map(x)).AsEnumerable();
        }

        public static IEnumerable<ItemDiscountType> Map(IEnumerable<ItemDiscountTypeDto> model)
        {
            return model.Select(x => Map(x)).AsEnumerable();
        }

        public static ItemDiscountTypeDto Map(ItemDiscountType model)
        {
            if (model == null)
            { return null; }

            return new ItemDiscountTypeDto
            {
                DiscountId = model.Id,
                DiscountPercentage = model.DiscountPercentage,
                StartDate = model.StartDate,
                EndDate = model.EndDate,
                Amount = model.Amount
            };
        }
    }
}
