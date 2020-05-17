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
    [Route("api/Employee")]
    //[ApiVersion("1.0")]
    //[ApiVersion("1.1")]
    [ApiController]
    public class EmployeeController : ControllerBase
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

        [HttpPost("AddProjectEmployeeToProject", Name = "AddProjectEmployeeToProject")]
        public void AddProjectEmployeeToProject([FromBody] ProjectEmployeeDto value)
        {
            _employeeService.CreateProjectEmployee(ProjectEmployeeMapper.Map(value));
        }

        [HttpPost("AddProjectDrivingToProject", Name = "AddProjectDrivingToProject")]
        public void AddProjectDrivingToProject([FromBody] ProjectDrivingDto value)
        {
            _employeeService.Create(ProjectDrivingMapper.Map(value));
        }

        [HttpGet("search/{searchString}", Name = "GetFilteredEmployees")]
        public IEnumerable<EmployeeDto> GetFilteredCustomers(string searchString)
        {
            return _employeeService.GetFilteredEmployees(searchString).Select(a => EmployeeMapper.Map(a));
        }
    }
}
