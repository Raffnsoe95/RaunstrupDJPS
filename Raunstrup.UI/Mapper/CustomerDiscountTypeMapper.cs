using Raunstrup.Contract.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Raunstrup.UI.Models
{
    public class CustomerDiscountTypeMapper
    {

        public static CustomerDiscountTypeViewModel Map(CustomerDiscountTypeDto dto)
        {
            if (dto == null)
            { return null; }
            return new CustomerDiscountTypeViewModel
            {
                Id = dto.Id,
                Name = dto.Name,
                Active = dto.active,
                CustomerId = dto.CustomerId,
                DiscountPercent = dto.DiscountPercent
            };
        }

        public static IEnumerable<CustomerDiscountTypeViewModel> Map(IEnumerable<CustomerDiscountTypeDto> model)
        {
            return model.Select(x => Map(x)).AsEnumerable();
        }

        public static IEnumerable<CustomerDiscountTypeDto> Map(IEnumerable<CustomerDiscountTypeViewModel> model)
        {
            return model.Select(x => Map(x)).AsEnumerable();
        }

        public static CustomerDiscountTypeDto Map(CustomerDiscountTypeViewModel model)
        {
            if (model == null)
            { return null; }
            return new CustomerDiscountTypeDto
            {
                Id = model.Id,
                Name = model.Name,
                active=model.Active,
                CustomerId = model.CustomerId,
                DiscountPercent=model.DiscountPercent

            };
        }
    }
}
