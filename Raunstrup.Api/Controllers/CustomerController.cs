using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Raunstrup.Api.Models;
using Raunstrup.Contract.DTOs;
using Raunstrup.BusinessLogic.ServiceInterfaces;
using Raunstrup.DataAccess.Model;
using System.Data;
using Microsoft.EntityFrameworkCore;
using Raunstrup.DataAccess;
using Org.BouncyCastle.Asn1.Cmp;
using Microsoft.EntityFrameworkCore.Internal;

namespace Raunstrup.Api.Controllers
{
    [Produces("application/json")]
    [Route("api/Customers")]
    //[ApiVersion("1.0")]
    //[ApiVersion("1.1")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _customerService;
        private readonly IProjectService _projectService;

        public CustomerController(ICustomerService customerService, IProjectService projectService)
        {
            _projectService = projectService;
            _customerService = customerService;
        }

        // GET: api/Customer
        [HttpGet]
        public IEnumerable<CustomerDto> Get()
        {
            try
            {
                return _customerService.GetAll().Select(a => CustomerMapper.Map(a));
            }
            catch (Exception) { throw; }
        }

        // GET: api/Customer/5
        [HttpGet("{id}")]
        public CustomerDto Get(int id)
        {
            try
            {
                return CustomerMapper.Map(_customerService.Get(id));
            }
            catch (Exception) { throw; }
        }

        // POST: api/Customer
        [HttpPost]
        public ActionResult<CustomerDto> Post([FromBody] CustomerDto value)
        {
            try
            {
                _customerService.Create(CustomerMapper.Map(value));
                return value;
            }
            catch(Exception dbe)
            {
                Customer customer = (Customer)dbe.Data["dbvalue"];
                return Conflict(CustomerMapper.Map(customer));
            }
        }

        // PUT: api/Customer/5
        [HttpPut("{id}")]
        public ActionResult<CustomerDto> Put(int id, [FromBody] CustomerDto value)
        {
            
                try
                {
                    _customerService.Update(CustomerMapper.Map(value));
                    return value;
                }
                catch (DbUpdateConcurrencyException dbu)
                {
                    Customer customer = (Customer)dbu.Data["dbvalue"];
                    return Conflict(CustomerMapper.Map(customer));
                }
            
            catch (Exception dbe)
            {
                Customer customer = (Customer)dbe.Data["dbvalue"];
                return new StatusCodeResult((int)500);
            }
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            try
            {
                _customerService.Delete(id);
            }
            catch (Exception) { throw; }
        }

        [HttpPut("AddCustomerToProject", Name = "AddCustomerToProject")]
        public void AddCustomerToProject([FromBody] ProjectDto value)
        {
            try
            {
                _projectService.AddCustomerToProject(ProjectMapper.Map(value));

            }
            catch (Exception) { throw; }
        }

        [HttpGet("search/{searchString}", Name = "GetFilteredCustomers")]
        public IEnumerable<CustomerDto> GetFilteredCustomers(string searchString)
        {
            try
            {
                return _customerService.GetFilteredCustomers(searchString).Select(a => CustomerMapper.Map(a));

            }
            catch (Exception) { throw; }
        }

        
        [HttpGet("GetAllCustomerDiscountType")]
        public IEnumerable<CustomerDiscountTypeDto> GetAllCustomerDiscountType()
        {
            return _customerService.GetAllCustomerDiscountType().Select(a => CustomerMapper.Map(a));
          
        }

        [HttpGet("getcustomerdiscounttype/{Id}", Name = "getcustomerdiscounttype")]
        public CustomerDiscountTypeDto CustomerDiscountType(int id)
        {
            
                return CustomerMapper.Map(_customerService.GetCustomerDiscountType(id));

            
          
            }
    }
}
