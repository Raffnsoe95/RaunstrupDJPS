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
    [Route("api/WorkingHours")]
    //[ApiVersion("1.0")]
    //[ApiVersion("1.1")]
    [ApiController]
    public class WorkingHoursController : ControllerBase
    {
        private readonly IWorkingHoursService _workinghoursService;

        public WorkingHoursController(IWorkingHoursService workinghoursService)
        {
            _workinghoursService = workinghoursService;
        }
        // GET: api/WoringHours
        [HttpGet]
        public IEnumerable<WorkingHoursDto> Get()
        {
            return _workinghoursService.GetAll()
                .Select(a => WorkingHoursMapper
                .Map(a))
                .ToList();
        }

        // GET: api/WorkingHours/5
        [HttpGet("{id}")]
        public WorkingHoursDto Get(int id)
        {
            //den skal aflevere en dto
            //ud fra en rigtig model, vel
            return WorkingHoursMapper.Map(_workinghoursService.Get(id));
        }

        // POST: api/WorkingHours
        [HttpPost]
        public void Post([FromBody] WorkingHoursDto value)
        {
            _workinghoursService.Create(WorkingHoursMapper.Map(value));
        }

        // PUT: api/Customer/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] WorkingHoursDto value)
        {
            _workinghoursService.Update(WorkingHoursMapper.Map(value));
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _workinghoursService.Delete(id);
        }
    }
}
