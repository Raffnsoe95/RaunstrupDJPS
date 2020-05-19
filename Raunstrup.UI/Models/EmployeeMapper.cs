using System.Collections.Generic;
using System.Linq;
using Raunstrup.Contract.DTOs;

namespace Raunstrup.UI.Models
{
    public class EmployeeMapper
    {
        public static EmployeeViewModel Map(EmployeeDto dto)
        {
            if(dto == null)
            { return null; }

            return new EmployeeViewModel
            { 
                Id = dto.Id,
                Name = dto.Name,
                Phone = dto.Phone,
                Active = dto.Active,
                Specialty = SpecialtyMapper.Map(dto.Specialty),
                Type = TypeMapper.Map(dto.Type),
                ManagerID = dto.ManagerID,
                Manager = EmployeeMapper.Map(dto.Manager),
                RowVersion = dto.RowVersion,
                Department = DepartmentMapper.Map(dto.Department)
            };
        }

        public static IEnumerable<EmployeeViewModel> Map(IEnumerable<EmployeeDto> model)
        {
            return model.Select(x => Map(x)).AsEnumerable();
        }
        public static IEnumerable<EmployeeDto> Map(IEnumerable<EmployeeViewModel> model)
        {
            return model.Select(x => Map(x)).AsEnumerable();
        }

        public static EmployeeDto Map(EmployeeViewModel model)
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
                Employee=EmployeeMapper.Map(dto),
                EmployeeID=dto.Id

            };
        }
        public static IEnumerable<EstWorkingHoursEmployeeViewModel> MapEst(IEnumerable<EmployeeDto> model)
        {
            return model.Select(x => MapEst(x)).AsEnumerable();
        }
    }
}
