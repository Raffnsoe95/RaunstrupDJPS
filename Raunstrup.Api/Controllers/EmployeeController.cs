using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Raunstrup.Api.Models;
using Raunstrup.Contract.DTOs;
using Raunstrup.BusinessLogic.ServiceInterfaces;
using Raunstrup.DataAccess.Model;

namespace Raunstrup.Api.Controllers
{
    [Produces("application/json")]
    [Route("api/Employee")]
    //[ApiVersion("1.0")]
    //[ApiVersion("1.1")]
    [ApiController]
    public class EmployeeController
    {
        private readonly IEmployeeService _employeeService;

        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        // GET: api/Movies
        [HttpGet]
        public IEnumerable<EmployeeDto> Get()
        {
            return _employeeService.GetAll().Select(a => EmployeeMapper.Map(a));
        }

        // GET: api/Movies/5
        [HttpGet("{id}")]
        //[ApiVersion("1.1")]
        public EmployeeDto Get(int id)
        {
            return EmployeeMapper.Map(_employeeService.Get(id));
        }

        // POST: api/Movies
        [HttpPost]
        public void Post([FromBody] EmployeeDto value)
        {
            _employeeService.Create(EmployeeMapper.Map(value));
        }

        // PUT: api/Movies/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] EmployeeDto value)
        {
            _employeeService.Update(EmployeeMapper.Map(value));
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _employeeService.Delete(id);
        }
    }
}
