//using Raunstrup.Contract.DTOs;
using Raunstrup.Contract.DTOs;
using Raunstrup.DataAccess.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Raunstrup.Api.Models
{
    public class SpecialtyMapper
    {
        public static Specialty Map(SpecialtyDto dto)
        {
            if (dto == null)
            {
                return null;
            }

            return new Specialty
            { 
                Id = dto.Id, 
                Bonus = dto.Bonus,
                Title = dto.Title
            };
        }

        public static IEnumerable<SpecialtyDto> Map(IEnumerable<Specialty> model)
        {
            return model.Select(x => Map(x)).AsEnumerable();
        }
        public static IEnumerable<Specialty> Map(IEnumerable<SpecialtyDto> model)
        {
            return model.Select(x => Map(x)).AsEnumerable();
        }

        public static SpecialtyDto Map(Specialty model)
        {
            return new SpecialtyDto
            {
                Id = model.Id,
                Bonus = model.Bonus,
                Title = model.Title
            };
        }
    }
}
