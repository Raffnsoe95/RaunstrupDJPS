using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Raunstrup.Contract.DTOs;
using Raunstrup.DataAccess.Model;

namespace Raunstrup.Api.Models
{
    public class CustomerDiscountTypeMapper
    {
        public static CustomerDiscountType Map(CustomerDiscountTypeDto dto)
        {
            if (dto == null)
            {
                return null;
            }

            return new CustomerDiscountType
            {
                Id = dto.Id,
                Name = dto.Name,
                Active=dto.active,
                DiscountPercent=dto.DiscountPercent
            };
        }

        public static IEnumerable<CustomerDiscountTypeDto> Map(IEnumerable<CustomerDiscountType> model)
        {
            return model.Select(x => Map(x)).AsEnumerable();
        }

        public static IEnumerable<CustomerDiscountType> Map(IEnumerable<CustomerDiscountTypeDto> model)
        {
            return model.Select(x => Map(x)).AsEnumerable();
        }

        public static CustomerDiscountTypeDto Map(CustomerDiscountType model)
        {
            if (model == null)
            { return null; }

            return new CustomerDiscountTypeDto
            {
                Id = model.Id,
                Name = model.Name,
                active=model.Active,
                DiscountPercent=model.DiscountPercent
                
            };
        }
    }
}

