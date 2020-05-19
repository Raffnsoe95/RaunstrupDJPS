using System.Collections.Generic;
using System.Linq;
using Raunstrup.Contract.DTOs;

namespace Raunstrup.UI.Models
{
    public class EmployeeDetailsMapper
    {
        public static EmployeeDetailsViewModel Map(EmployeeDto dto)
        {
            if(dto == null)
            { return null; }

            return new EmployeeDetailsViewModel
            { 
                Id = dto.Id,
                Name = dto.Name,
                Phone = dto.Phone,
                Active = dto.Active,
                Specialty = SpecialtyMapper.Map(dto.Specialty),
                Projects = ProjectMapper.Map(dto.Projects).ToList(),
                Type = TypeMapper.Map(dto.Type),
                ManagerID = dto.ManagerID,
                Manager = EmployeeMapper.Map(dto.Manager),
                RowVersion = dto.RowVersion,
                Department = DepartmentMapper.Map(dto.Department)
            };
        }

        public static IEnumerable<EmployeeDetailsViewModel> Map(IEnumerable<EmployeeDto> model)
        {
            return model.Select(x => Map(x)).AsEnumerable();
        }
        public static IEnumerable<EmployeeDto> Map(IEnumerable<EmployeeDetailsViewModel> model)
        {
            return model.Select(x => Map(x)).AsEnumerable();
        }

        public static EmployeeDto Map(EmployeeDetailsViewModel model)
        {
            if (model == null)
            { return null; }

            return new EmployeeDto
            { 
                Id = model.Id,
                Name = model.Name,
                Phone = model.Phone,
                Active = model.Active,
                Specialty = SpecialtyMapper.Map(model.Specialty),
                Type = TypeMapper.Map(model.Type),
                ManagerID = model.ManagerID,
                Manager = EmployeeMapper.Map(model.Manager),
                //Projects = ProjectMapper.Map(model.).ToList(),
                Department = DepartmentMapper.Map(model.Department),
                RowVersion = model.RowVersion
            };
        }
        public static EstWorkingHoursEmployeeViewModel MapEst(EmployeeDto dto)
        {
            if (dto == null)
            { return null; }

            return new EstWorkingHoursEmployeeViewModel
            {
                Id = dto.Id,
               Employee=EmployeeMapper.Map( dto)
            };
        }
        public static IEnumerable<EstWorkingHoursEmployeeViewModel> MapEst(IEnumerable<EmployeeDto> model)
        {
            return model.Select(x => MapEst(x)).AsEnumerable();
        }
    }
}
