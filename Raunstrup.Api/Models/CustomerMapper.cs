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
    public static class CustomerMapper
    {

        public static Customer Map(CustomerDto dto)
        {
            if (dto == null)
            {
                return null;
            }
            return new Customer
            { Id = dto.Id, 
                Name = dto.Name , 
                Phone = dto.Phone, 
                Address = dto.Address, 
                Email = dto.Email, 
                Active=dto.Active, 
                RowVersion=dto.Rowversion, 
                CustomerDiscountType=CustomerDiscountTypeMapper.Map( dto.CustomerDiscountType),
            CustomerDiscountTypeID=dto.CustomerDiscountTypeId
            };
        }

        public static IEnumerable<CustomerDto> Map(IEnumerable<Customer> model)
        {
            return model.Select(x => Map(x)).AsEnumerable();
        }

        public static CustomerDto Map(Customer model)
        {
            if (model == null)
            {
                return null;
            }
            return new CustomerDto
            { Id = model.Id,
                Name = model.Name, 
                Phone = model.Phone, 
                Address = model.Address, 
                Email=model.Email, 
                Active=model.Active, 
                Rowversion=model.RowVersion, 
                CustomerDiscountType=CustomerDiscountTypeMapper.Map(model.CustomerDiscountType),
            CustomerDiscountTypeId=model.CustomerDiscountTypeID
            };
        }
    
    public static IEnumerable<CustomerDiscountTypeDto> Map (IEnumerable<CustomerDiscountType> model)
        {
            return model.Select(x => Map(x)).AsEnumerable();
        }


        public static CustomerDiscountTypeDto Map(CustomerDiscountType model)
        {
            if (model == null)
            {
                return null;
            }
            return new CustomerDiscountTypeDto
            { Id = model.Id, 
                Name = model.Name, 
                DiscountPercent=model.DiscountPercent,
                Rowversion = model.RowVersion,
           
            };
        }

    }
}
