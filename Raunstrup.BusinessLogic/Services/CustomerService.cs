using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Raunstrup.BusinessLogic.ServiceInterfaces;
using Raunstrup.DataAccess;
using Raunstrup.DataAccess.Context;
using Raunstrup.DataAccess.Model;
namespace Raunstrup.BusinessLogic.Services
{
    public class CustomerService:ICustomerService
    {
       
        private readonly RaunstrupContext _context;

            public CustomerService(RaunstrupContext context)
            {
                _context = context;
            }

            IEnumerable<Customer> ICustomerService.GetAll()
            {
                return _context.customers
                .Where(a=>a.Active==true)
                .Include(c=>c.CustomerDiscountType)
            .ToList();
            }

            Customer ICustomerService.Get(int id)
            {
            return _context.customers
           .Include(e => e.CustomerDiscountType)
           .FirstOrDefault(x => x.Id == id);


        }

            void ICustomerService.Create(Customer customer)
            {
                _context.customers.Add(customer);
                _context.SaveChanges();
            }

            void ICustomerService.Update(Customer customer)
            {
                _context.customers.Update(customer);
                _context.SaveChanges();
            }

            void ICustomerService.Delete(int id)
            {
                Customer tmpCustomer=_context.customers.Find(id);
            tmpCustomer.Active = false;
            _context.customers.Update(tmpCustomer);
            _context.SaveChanges();
            }
        void ICustomerService.AddCustomerToProject(Customer Customer)
        {
            _context.Customer.Add(Customer);
            _context.SaveChanges();
        }

        IEnumerable<Customer> ICustomerService.GetFilteredCustomers(string searchString)
        {
            return _context.customers
                .Where(f=>f.Name.ToUpper().Contains(searchString.ToUpper()))
                .Where(a=>a.Active==true)
                .Include(c => c.CustomerDiscountType)
            .ToList();
        }
        IEnumerable<CustomerDiscountType> ICustomerService.GetAllCustomerDiscountType()
        {
            return _context.CustomerDiscountTypes.ToList();
        }
    }
    }

