using System.Collections.Generic;
using System.Linq;
using Raunstrup.Contract.DTOs;

namespace Raunstrup.UI.Models
{
    public class ItemDiscountTypeMapper
    {
        public static ItemDiscountTypeViewModel Map(ItemDiscountTypeDto dto)
        {
            if (dto == null)
            { return null; }

            return new ItemDiscountTypeViewModel
            {
                DiscountId = dto.DiscountId,
                DiscountPercentage = dto.DiscountPercentage,
                StartDate = dto.StartDate,
                EndDate = dto.EndDate,
                Amount = dto.Amount,
                ItemId = dto.ItemId,
                RowVersion = dto.RowVersion,
            };
        }

        public static IEnumerable<ItemDiscountTypeViewModel> Map(IEnumerable<ItemDiscountTypeDto> model)
        {
            return model.Select(x => Map(x)).AsEnumerable();
        }
        public static IEnumerable<ItemDiscountTypeDto> Map(IEnumerable<ItemDiscountTypeViewModel> model)
        {
            return model.Select(x => Map(x)).AsEnumerable();
        }
        public static ItemDiscountTypeDto Map(ItemDiscountTypeViewModel model)
        {
            if (model == null)
            { return null; }

            return new ItemDiscountTypeDto
            {
                DiscountId = model.DiscountId,
                //DiscountAmount = model.DiscountAmount,
                StartDate = model.StartDate,
                EndDate = model.EndDate,
                Amount = model.Amount,
                ItemId = model.ItemId,
                RowVersion = model.RowVersion,
            };
        }

    }
}

