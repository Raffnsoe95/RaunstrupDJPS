using Raunstrup.Contract.DTOs;
using Raunstrup.DataAccess.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Raunstrup.UI.Models
{
    public class TypeMapper
    {

        public static TypeViewModel Map(TypeDto dto)
        {
            if (dto == null)
            { return null; }
            return new TypeViewModel
            {
                Id = dto.Id, 
                EmployeeId =dto.EmployeeId, 
                HourlyPrice = dto.HourlyPrice, 
                Title = dto.Title
            };
        }

        public static IEnumerable<TypeViewModel> Map(IEnumerable<TypeDto> model)
        {
            return model.Select(x => Map(x)).AsEnumerable();
        }

        public static IEnumerable<TypeDto> Map(IEnumerable<TypeViewModel> model)
        {
            return model.Select(x => Map(x)).AsEnumerable();
        }

        public static TypeDto Map(TypeViewModel type)
        {
            if (type == null)
            { return null; }
            return new TypeDto
            {
                Id = type.Id,
                EmployeeId = type.EmployeeId,
                HourlyPrice = type.HourlyPrice,
                Title = type.Title
            };
        } 
    }
}
