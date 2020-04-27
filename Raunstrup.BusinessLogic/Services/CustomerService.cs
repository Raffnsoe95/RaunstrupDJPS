using System;
using System.Collections.Generic;
using Raunstrup.BusinessLogic.ServiceInterfaces;

using Raunstrup.DataAccess;

namespace Raunstrup.BusinessLogic.Services
{
    public class CustomerService:ICustomerService
    {
       
        private readonly MvcCustomerContext _context;

            public CustomerService(MvcMovieContext context)
            {
                _context = context;
            }

            IEnumerable<Customer> ICustomerService.GetAll()
            {
                return _context.Movie.ToList();
            }

            Customer ICustomerService.Get(int id)
            {
                return _context.Customer.Find(id);
            }

            void ICustomerService.Create(Customer movie)
            {
                _context.Movie.Add(movie);
                _context.SaveChanges();
            }

            void ICustomerService.Update(Customer customer)
            {
                _context.Movie.Update(customer);
                _context.SaveChanges();
            }

            void ICustomerService.Delete(int id)
            {
                _context.Movie.Remove(_context.Movie.Find(id));
                _context.SaveChanges();
            }
        }
    }

