using Raunstrup.Contract.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Raunstrup.UI.Models
{
    public class ProjectEmployeeMapper
    {
            public static ProjectEmployeeViewModel Map(ProjectEmployeeDto dto)
        {
            return new ProjectEmployeeViewModel
            { EmployeeId = dto.Id, EmployeeName = dto.EmployeeName, EstWorkingHours = dto.EstWorkingHours, ProjectId = dto.ProjectId, Employee = EmployeeMapper.Map(dto.Employee) };
        }

        public static IEnumerable<ProjectEmployeeViewModel> Map(IEnumerable<ProjectEmployeeDto> model)
        {
            return model.Select(x => Map(x)).AsEnumerable();
        }
        public static IEnumerable<ProjectEmployeeDto> Map(IEnumerable<ProjectEmployeeViewModel> model)
        {
            return model.Select(x => Map(x)).AsEnumerable();
        }

        public static ProjectEmployeeDto Map(ProjectEmployeeViewModel model)
        {
            return new ProjectEmployeeDto
            {Id = model.EmployeeId, EmployeeName = model.EmployeeName, EstWorkingHours = model.EstWorkingHours, ProjectId = model.ProjectId, Employee = EmployeeMapper.Map(model.Employee) };

        }
    }
}
