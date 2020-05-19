using Raunstrup.Contract.DTOs;
using Raunstrup.DataAccess.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Raunstrup.Api.Models
{
    public class ProjectEmployeeMapper
    {
        public static ProjectEmployee Map(ProjectEmployeeDto dto)
        {
            return new ProjectEmployee
            {
                EmployeeID = dto.Id,
                EstWorkingHours = dto.EstWorkingHours,
                Employee = EmployeeMapper.Map(dto.Employee),
                ProjectId = dto.ProjectId
            };
        }

        public static IEnumerable<ProjectEmployeeDto> Map(IEnumerable<ProjectEmployee> model)
        {
            return model.Select(x => Map(x)).AsEnumerable();
        }

        public static IEnumerable<ProjectEmployee> Map(IEnumerable<ProjectEmployeeDto> model)
        {
            return model.Select(x => Map(x)).AsEnumerable();
        }

        public static ProjectEmployeeDto Map(ProjectEmployee addEmployee)
        {
            return new ProjectEmployeeDto
            {
                Id = addEmployee.EmployeeID,
                EstWorkingHours = addEmployee.EstWorkingHours,
                Employee = EmployeeMapper.Map(addEmployee.Employee),
                ProjectId = addEmployee.ProjectId
            };
        }
    }
}
