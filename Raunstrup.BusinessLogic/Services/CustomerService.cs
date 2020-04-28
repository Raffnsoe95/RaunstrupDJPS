using System;
using System.Collections.Generic;
using System.Linq;
using Raunstrup.BusinessLogic.ServiceInterfaces;

using Raunstrup.DataAccess;
using Raunstrup.DataAccess.Context;

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
                return _context.customers.ToList();
            }

            Customer ICustomerService.Get(int id)
            {
                return _context.customers.Find(id);
            }

            void ICustomerService.Create(Customer movie)
            {
                _context.customers.Add(movie);
                _context.SaveChanges();
            }

            void ICustomerService.Update(Customer customer)
            {
                _context.customers.Update(customer);
                _context.SaveChanges();
            }

            void ICustomerService.Delete(int id)
            {
                _context.customers.Remove(_context.customers.Find(id));
                _context.SaveChanges();
            }
        }
    }

