using Raunstrup.Contract.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;


namespace Raunstrup.Contract.Services
{
   public interface ICustomerService
    {
        Task<IEnumerable<CustomerDto>> GetCustomerAsync();
        Task<CustomerDto> GetCustomerAsync(int id);
        Task AddAsync(CustomerDto customer);
        Task UpdateAsync(int id, CustomerDto customer);
        Task RemoveAsync(int id);
        Task AddAsync(int id, int projectid);

        Task<IEnumerable<CustomerDto>> GetFilteredCustomers(string searchString);

         Task<IEnumerable<CustomerDiscountTypeDto>> GetAllCustomerDiscountType();
    }
}
