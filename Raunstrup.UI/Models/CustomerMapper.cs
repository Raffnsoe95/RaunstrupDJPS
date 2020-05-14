using Raunstrup.Contract;
using Raunstrup.Contract.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Raunstrup.UI.Models
{
    public static class CustomerMapper
    {

        public static CustomerViewModel Map(CustomerDto dto)
        {
            if (dto == null)
                return null;
            return new CustomerViewModel
            { Id=dto.Id, Name=dto.Name, Phone=dto.Phone, Address=dto.Address, Email=dto.Email, Active=dto.Active, Rowversion=dto.Rowversion, CustomerDiscountType=CustomerDiscountTypeMapper.Map( dto.CustomerDiscountType), CustomerDiscountTypeId=dto.CustomerDiscountTypeId};
        }

        public static IEnumerable<CustomerViewModel> Map(IEnumerable<CustomerDto> dtos)
        {
            return dtos.Select(x => Map(x)).AsEnumerable();
        }

        public static CustomerDto Map(CustomerViewModel view)
        {
            if (view == null)
                return null;
            return new CustomerDto
            { Id = view.Id, Name = view.Name, Phone = view.Phone, Address = view.Address, Email = view.Email, Active = view.Active, Rowversion = view.Rowversion, CustomerDiscountType=CustomerDiscountTypeMapper.Map( view.CustomerDiscountType), CustomerDiscountTypeId=view.CustomerDiscountTypeId };
        }

        public static CustomerDiscountTypeViewModel Map(CustomerDiscountTypeDto dto)
        {
            if (dto == null)
                return null;
            return new CustomerDiscountTypeViewModel
            { Id = dto.Id, Name = dto.Name, Active=dto.active, DiscountPercent=dto.DiscountPercent, Rowversion=dto.Rowversion };
        }


        public static IEnumerable<CustomerDiscountTypeViewModel> Map(IEnumerable<CustomerDiscountTypeDto> dtos)
        {
            return dtos.Select(x => Map(x)).AsEnumerable();
        }

        public static CustomerViewModel Map(CECustomerViewModel view)
        {
            if (view == null)
                return null;
            return new CustomerViewModel
            { Id = view.Id, 
                Name = view.Name, 
                Phone = view.Phone, 
                Address = view.Address,
                Email = view.Email, 
                Active = view.Active, 
                Rowversion = view.Rowversion, 
                CustomerDiscountType =  view.CustomerDiscountType,
                CustomerDiscountTypeId=view.SelectedCustomerDiscountViewModel

            };
    

        
        }
        public static CECustomerViewModel MaptoCE(CustomerDto dto)
        {
            if (dto == null)
                return null;
            return new CECustomerViewModel
            {
                Id = dto.Id,
                Name = dto.Name,
                Phone = dto.Phone,
                Address = dto.Address,
                Email = dto.Email,
                Active = dto.Active,
                Rowversion = dto.Rowversion,
                CustomerDiscountType =Map( dto.CustomerDiscountType),
                SelectedCustomerDiscountViewModel =Convert.ToInt32(dto.CustomerDiscountTypeId)

            };
        }

    }
}
