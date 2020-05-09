using Raunstrup.Contract.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Raunstrup.UI.Models
{
    public class DepartmentMapper
    {
        public static DepartmentViewModel Map(DepartmentDto dto)
        {
            if (dto == null)
            { return null; }
            return new DepartmentViewModel
            {
                Id = dto.Id,
                Name =dto.Name,
                EmployeeId = dto.EmployeeId,
            };
        }

        public static IEnumerable<DepartmentViewModel> Map(IEnumerable<DepartmentDto> model)
        {
            return model.Select(x => Map(x)).AsEnumerable();
        }

        public static IEnumerable<DepartmentDto> Map(IEnumerable<DepartmentViewModel> model)
        {
            return model.Select(x => Map(x)).AsEnumerable();
        }

        public static DepartmentDto Map(DepartmentViewModel model)
        {
            if (model == null)
            { return null; }
            return new DepartmentDto
            {
                Id = model.Id,
                Name = model.Name,
                EmployeeId = model.EmployeeId,
                
            };
        }

    }
}
