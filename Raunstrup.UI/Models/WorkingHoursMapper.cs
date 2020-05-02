using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Raunstrup.Contract.DTOs;

namespace Raunstrup.UI.Models
{
    public class WorkingHoursMapper
    {
        public static WorkingHoursViewModel Map(WorkingHoursDto dto)
        {
            return new WorkingHoursViewModel
            { Id = dto.Id,Amount = dto.Amount, EmployeeId = dto.EmployeeId, HourlyPrice = dto.HourlyPrice, ProjectId=dto.ProjectId, Employee=EmployeeMapper.Map( dto.Employee) };
        }

        public static IEnumerable<WorkingHoursViewModel> Map(IEnumerable<WorkingHoursDto> model)
        {
            return model.Select(x => Map(x)).AsEnumerable();
        }

        public static WorkingHoursDto Map(WorkingHoursViewModel model)
        {
            return new WorkingHoursDto
            { Id = model.Id, Amount = model.Amount, EmployeeId = model.EmployeeId, HourlyPrice = model.HourlyPrice, ProjectId = model.ProjectId, Employee =EmployeeMapper.Map( model.Employee) };

        }
    }
}
