using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
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
                return _context.Customers
                .Where(a=>a.Active==true)
                .Include(c=>c.CustomerDiscountType)
            .ToList();
            }

            Customer ICustomerService.Get(int id)
            {
            return _context.Customers
           .Include(e => e.CustomerDiscountType)
           .FirstOrDefault(x => x.Id == id);


            }

            void ICustomerService.Create(Customer customer)
            {
            try
            {
                CustomerDiscountType customerDiscountType = _context.CustomerDiscountTypes.Find(customer.CustomerDiscountTypeID);
                customer.CustomerDiscountType = customerDiscountType;
                _context.Customers
                .Add(customer);
                _context.SaveChanges();
            }
            catch (Exception dbe)
            {

               // var exceptionEntry = dbe.Entries.Single();
               // var databaseEntry = exceptionEntry.GetDatabaseValues();
                //customer = (Customer)databaseEntry.ToObject();
              
                dbe.Data.Add("dbvalue", customer);
                throw;
            }
            }

            void ICustomerService.Update(Customer customer)
            {
            CustomerDiscountType customerDiscountType = _context.CustomerDiscountTypes.Find(customer.CustomerDiscountTypeID);
            
            try
            {
                customer.CustomerDiscountType = customerDiscountType;
                _context.Customers.Update(customer);
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException dbu)

            {
                var exceptionEntry = dbu.Entries.Single();
                var databaseEntry = exceptionEntry.GetDatabaseValues();
                customer = (Customer)databaseEntry.ToObject();
                customer.CustomerDiscountType = customerDiscountType;
                dbu.Data.Add("dbvalue", customer);
                throw;

            }


            
            }

            void ICustomerService.Delete(int id)
            {
            

            Customer tmpCustomer=_context.Customers.Find(id);

            tmpCustomer.Active = false;
            _context.Customers.Update(tmpCustomer);
            _context.SaveChanges();
            }
        void ICustomerService.AddCustomerToProject(Customer Customer)
        {
            _context.Customers.Add(Customer);
            _context.SaveChanges();
        }

        IEnumerable<Customer> ICustomerService.GetFilteredCustomers(string searchString)
        {
            return _context.Customers
                .Where(f=>f.Name.ToUpper().Contains(searchString.ToUpper()))
                .Where(a=>a.Active==true)
                .Include(c => c.CustomerDiscountType)
            .ToList();
        }
        IEnumerable<CustomerDiscountType> ICustomerService.GetAllCustomerDiscountType()
        {
            return _context.CustomerDiscountTypes.ToList();
        }

        CustomerDiscountType ICustomerService.GetCustomerDiscountType(int id)
        {
            return _context.CustomerDiscountTypes.Find(id);
           
           


        }
    }
    }

