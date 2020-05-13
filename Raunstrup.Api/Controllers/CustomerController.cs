using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Raunstrup.Api.Models;
using Raunstrup.Contract.DTOs;
using Raunstrup.BusinessLogic.ServiceInterfaces;
using Raunstrup.DataAccess.Model;

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

        public CustomerController(ICustomerService movieService, IProjectService projectService)
        {
            _projectService = projectService;
            _customerService = movieService;
        }

        // GET: api/Customer
        [HttpGet]
        public IEnumerable<CustomerDto> Get()
        {
            return _customerService.GetAll().Select(a => CustomerMapper.Map(a));
        }

        // GET: api/Customer/5
        [HttpGet("{id}")]
        public CustomerDto Get(int id)
        {
            return CustomerMapper.Map(_customerService.Get(id));
        }

        // POST: api/Customer
        [HttpPost]
        public void Post([FromBody] CustomerDto value)
        {
            _customerService.Create(CustomerMapper.Map(value));
        }

        // PUT: api/Customer/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] CustomerDto value)
        {
            _customerService.Update(CustomerMapper.Map(value));
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _customerService.Delete(id);
        }

        [HttpPut("AddCustomerToProject", Name = "AddCustomerToProject")]
        public void AddCustomerToProject([FromBody] ProjectDto value)
        {
            _projectService.AddCustomerToProject(ProjectMapper.Map(value));
        }

        [HttpGet("search/{searchString}", Name = "GetFilteredCustomers")]
        public IEnumerable<CustomerDto> GetFilteredCustomers(string searchString)
        {
            return _customerService.GetFilteredCustomers(searchString).Select(a => CustomerMapper.Map(a));
        }

        // en metode der henter en liste af customerdiscounttypes
        [HttpGet("GetAllCustomerDiscountType")]
        public IEnumerable<CustomerDiscountTypeDto> GetAllCustomerDiscountType()
        {
            return _customerService.GetAllCustomerDiscountType().Select(a => CustomerMapper.Map(a));
        }
    }
}
