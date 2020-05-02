using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Raunstrup.Api.Models;
using Raunstrup.Contract.DTOs;
using Raunstrup.BusinessLogic.ServiceInterfaces;

namespace Raunstrup.Api.Controllers
{
    [Produces("application/json")]
    [Route("api/Customer")]
    //[ApiVersion("1.0")]
    //[ApiVersion("1.1")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _customerService;

        public CustomerController(ICustomerService movieService)
        {
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
    }
}
