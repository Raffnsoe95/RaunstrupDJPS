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
    [Route("api/Project")]
    //[ApiVersion("1.0")]
    //[ApiVersion("1.1")]
    [ApiController]
    public class ProjectController : ControllerBase


    {
        private readonly IProjectService _projectService;

        public ProjectController(IProjectService projectService)
        {
            _projectService = projectService;
        }
        // GET: api/Customer
        [HttpGet]
        public IEnumerable<ProjectDto> Get()
        {

            return _projectService.GetAll().Select(a => ProjectMapper.Map(a));
        }

        // GET: api/Customer/5
        [HttpGet("{id}")]
        public ProjectDto Get(int id)
        {
            return ProjectMapper.Map(_projectService.Get(id));
        }

        // POST: api/Customer
        [HttpPost]
        public void Post([FromBody] ProjectDto value)
        {
            _projectService.Create(ProjectMapper.Map(value));
        }

        // PUT: api/Customer/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] ProjectDto value)
        {
            _projectService.Update(ProjectMapper.Map(value));
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _projectService.Delete(id);
        }
    }
}
