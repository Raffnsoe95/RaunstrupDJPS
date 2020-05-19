using Raunstrup.Contract;
using Raunstrup.Contract.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Raunstrup.UI.Models
{
    public class CustomerDetailsMapper
    {
        public static CustomerDetailsViewModel Map(CustomerDto dto)
        {
            if (dto == null)
                return null;
            return new CustomerDetailsViewModel
            {
                Id = dto.Id,
                Name = dto.Name,
                Phone = dto.Phone,
                Address = dto.Address,
                Email = dto.Email,
                Active = dto.Active,
                Rowversion = dto.Rowversion,
                CustomerDiscountType = CustomerDiscountTypeMapper.Map(dto.CustomerDiscountType),
                CustomerDiscountTypeId = dto.CustomerDiscountTypeId
            };
        }

        public static IEnumerable<CustomerDetailsViewModel> Map(IEnumerable<CustomerDto> dtos)
        {
            return dtos.Select(x => Map(x)).AsEnumerable();
        }

        public static CustomerDto Map(CustomerDetailsViewModel view)
        {
            if (view == null)
                return null;
            return new CustomerDto
            {
                Id = view.Id,
                Name = view.Name,
                Phone = view.Phone,
                Address = view.Address,
                Email = view.Email,
                Active = view.Active,
                Rowversion = view.Rowversion,
                CustomerDiscountType = CustomerDiscountTypeMapper.Map(view.CustomerDiscountType),
                CustomerDiscountTypeId = view.CustomerDiscountTypeId
            };
        }

    }
}
