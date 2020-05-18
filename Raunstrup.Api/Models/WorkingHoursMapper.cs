using Raunstrup.Contract.DTOs;
using Raunstrup.DataAccess.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Raunstrup.Api.Models
{
    public class WorkingHoursMapper
    {

        public static WorkingHours Map(WorkingHoursDto dto)
        {
            return new WorkingHours
            {
                Id = dto.Id,
                Amount = dto.Amount,
                EmployeeId=dto.EmployeeId,
                HourlyPrice =dto.HourlyPrice,
                Employee=EmployeeMapper.Map(dto.Employee),
                ProjectId=dto.ProjectId
            };
        }

        public static IEnumerable<WorkingHoursDto> Map(IEnumerable<WorkingHours> model)
        {
            return model.Select(x => Map(x)).AsEnumerable();
        }

        public static IEnumerable<WorkingHours> Map(IEnumerable< WorkingHoursDto> model)
        {
            return model.Select(x => Map(x)).AsEnumerable();
        }

        public static WorkingHoursDto Map(WorkingHours workingHours)
        {
            return new WorkingHoursDto
            {
                Id = workingHours.Id,
                Amount = workingHours.Amount,
                EmployeeId = workingHours.EmployeeId,
                HourlyPrice = workingHours.HourlyPrice,
                Employee = EmployeeMapper.Map(workingHours.Employee),
                ProjectId = workingHours.ProjectId
            };
        }
    }
}
