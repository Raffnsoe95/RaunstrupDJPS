using System;
using System.Collections.Generic;
using System.Text;
using Raunstrup.DataAccess;

namespace Raunstrup.BusinessLogic.ServiceInterfaces
{
    interface ICustomerService
    {
        
            IEnumerable<Customer> GetAll();
            Customer Get(int id);
            void Create(Customer customer);
            void Update(Customer customer);
            void Delete(int id);
        
    }
}
