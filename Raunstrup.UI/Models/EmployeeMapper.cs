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
                Specialties = SpecialtyMapper.Map(dto.Specialties).ToList(),
                Type = TypeMapper.Map(dto.Type),
                RowVersion = dto.RowVersion
            };
        }

        public static IEnumerable<EmployeeViewModel> Map(IEnumerable<EmployeeDto> model)
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
                Specialties = SpecialtyMapper.Map(model.Specialties).ToList(),
                Type = TypeMapper.Map(model.Type),
                RowVersion = model.RowVersion
            };
        }
    }
}
