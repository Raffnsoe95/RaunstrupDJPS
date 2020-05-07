using Raunstrup.Contract;
using Raunstrup.Contract.DTOs;
using Raunstrup.DataAccess;
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
            { Id = dto.Id, Name = dto.Name , Phone = dto.Phone, Address = dto.Address, Email = dto.Email, Active=dto.Active, Rowversion=dto.Rowversion };
        }

        public static IEnumerable<CustomerDto> Map(IEnumerable<Customer> model)
        {
            return model.Select(x => Map(x)).AsEnumerable();
        }

        public static CustomerDto Map(Customer model)
        {
            return new CustomerDto
            { Id = model.Id, Name = model.Name, Phone = model.Phone, Address = model.Address, Email=model.Email, Active=model.Active, Rowversion=model.Rowversion };
        }
    }
}
