using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Raunstrup.Contract.DTOs;
using Raunstrup.DataAccess.Model;

namespace Raunstrup.Api.Models
{
    public class DepartmentMapper
    {
        public static Department Map(DepartmentDto dto)
        {
            if (dto == null)
            {
                return null;
            }

            return new Department
            {
                Id = dto.Id,
                Name =dto.Name
            };
        }

        public static IEnumerable<DepartmentDto> Map(IEnumerable<Department> model)
        {
            return model.Select(x => Map(x)).AsEnumerable();
        }

        public static IEnumerable<Department> Map(IEnumerable<DepartmentDto> model)
        {
            return model.Select(x => Map(x)).AsEnumerable();
        }

        public static DepartmentDto Map(Department model)
        {
            if (model == null)
            { return null; }

            return new DepartmentDto
            {
                Id = model.Id,
                Name = model.Name
            };
        }
    }
}
