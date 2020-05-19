//using Raunstrup.Contract.DTOs;
using Raunstrup.Contract.DTOs;
using Raunstrup.DataAccess.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Raunstrup.Api.Models
{
    public class TypeMapper
    {
        public static EmployeeType Map(TypeDto dto)
        {
            if (dto == null)
            {
                return null;
            }

            return new EmployeeType
            {
                Id = dto.Id,
                HourlyPrice = dto.HourlyPrice,
                Title = dto.Title
            };
        }

        public static IEnumerable<TypeDto> Map(IEnumerable<EmployeeType> model)
        {
            return model.Select(x => Map(x)).AsEnumerable();
        }
        public static IEnumerable<EmployeeType> Map(IEnumerable<TypeDto> model)
        {
            return model.Select(x => Map(x)).AsEnumerable();
        }

        public static TypeDto Map(EmployeeType model)
        {
            if (model == null)
            { return null; }

            return new TypeDto
            { 
                Id = model.Id, 
                HourlyPrice = model.HourlyPrice,
                Title = model.Title
            };
        }
    }
}
