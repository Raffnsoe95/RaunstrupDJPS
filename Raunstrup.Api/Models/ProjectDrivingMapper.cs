using Raunstrup.Contract.DTOs;
using Raunstrup.DataAccess.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Raunstrup.Api.Models
{
    public class ProjectDrivingMapper
    {
        public static ProjectDriving Map(ProjectDrivingDto dto)
        {
            return new ProjectDriving
            {
                Id = dto.Id,
                Amount = dto.Amount,
                EmployeeId = dto.EmployeeId,
                Employee = EmployeeMapper.Map(dto.Employee),
                ProjectId = dto.ProjectId
            };
        }

        public static IEnumerable<ProjectDrivingDto> Map(IEnumerable<ProjectDriving> model)
        {
            return model.Select(x => Map(x)).AsEnumerable();
        }

        public static IEnumerable<ProjectDriving> Map(IEnumerable<ProjectDrivingDto> model)
        {
            return model.Select(x => Map(x)).AsEnumerable();
        }

        public static ProjectDrivingDto Map(ProjectDriving projectDriving)
        {
            return new ProjectDrivingDto
            {
                Id = projectDriving.Id,
                Amount = projectDriving.Amount,
                EmployeeId = projectDriving.EmployeeId,
                Employee = EmployeeMapper.Map(projectDriving.Employee),
                ProjectId = projectDriving.ProjectId
            };
        }
    }
}
