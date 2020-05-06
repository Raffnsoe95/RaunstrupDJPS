using Raunstrup.Contract.DTOs;
using Raunstrup.DataAccess.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Raunstrup.UI.Models
{
    public class SpecialtyMapper
    {

        public static SpecialtyViewModel Map(SpecialtyDto dto)
        {
            return new SpecialtyViewModel
            {
                Id = dto.Id, 
                Bonus = dto.Bonus,
                Title = dto.Title,
                EmployeeId = dto.EmployeeId
            };
        }

        public static IEnumerable<SpecialtyViewModel> Map(IEnumerable<SpecialtyDto> model)
        {
            return model.Select(x => Map(x)).AsEnumerable();
        }


        public static IEnumerable<SpecialtyDto> Map(IEnumerable<SpecialtyViewModel> model)
        {
            return model.Select(x => Map(x)).AsEnumerable();
        }

        public static SpecialtyDto Map(SpecialtyViewModel specialty)
        {
            return new SpecialtyDto
            {
                Id = specialty.Id,
                Bonus = specialty.Bonus,
                Title = specialty.Title,
                EmployeeId = specialty.EmployeeId
            };
        }

        

        

        
    }
}
