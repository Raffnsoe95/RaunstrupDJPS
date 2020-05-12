using System;
using System.Collections.Generic;
using System.Text;
using Raunstrup.Contract.DTOs;
using Raunstrup.DataAccess.Model;
using Raunstrup.DataAccess;


namespace Raunstrup.BusinessLogic.ServiceInterfaces
{
   public interface ICustomerService
    {
        
            IEnumerable<Customer> GetAll();
            Customer Get(int id);
            void Create(Customer customer);
            void Update(Customer customer);
            void Delete(int id);
            void AddCustomerToProject(Customer Customer);

        IEnumerable<Customer> GetFilteredCustomers(string searchString);

        IEnumerable<CustomerDiscountType> GetAllCustomerDiscountType();
    }
}
