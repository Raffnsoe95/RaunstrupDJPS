using Raunstrup.Contract.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Raunstrup.UI.Models
{
    public class ProjectDrivingMapper
    {

        public static ProjectDrivingViewModel Map(ProjectDrivingDto dto)
        {
            return new ProjectDrivingViewModel
            {
                Id = dto.Id,
                Amount = dto.Amount, 
                EmployeeId = dto.EmployeeId,
                Employee = EmployeeMapper.Map(dto.Employee), 
                UnitPrice = dto.UnitPrice,
                ProjectId = dto.ProjectId
            };
        }

        public static IEnumerable<ProjectDrivingViewModel> Map(IEnumerable<ProjectDrivingDto> model)
        {
            return model.Select(x => Map(x)).AsEnumerable().ToList();
        }

        public static IEnumerable<ProjectDrivingDto> Map(IEnumerable<ProjectDrivingViewModel> model)
        {
            return model.Select(x => Map(x)).AsEnumerable().ToList();
        }

        public static ProjectDrivingDto Map(ProjectDrivingViewModel projectDriving)
        {
            return new ProjectDrivingDto
            {
                Id = projectDriving.Id,
                Amount = projectDriving.Amount,
                EmployeeId = projectDriving.EmployeeId,
                Employee = EmployeeMapper.Map(projectDriving.Employee),
                UnitPrice = projectDriving.UnitPrice,
                ProjectId = projectDriving.ProjectId
            };
        }

        

        

        
    }
}
