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
            { Id = dto.Id, Name = dto.Name, Tlfnr = dto.Tlfnr, Active = dto.Active };
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
            { Id = model.Id, Name = model.Name, Tlfnr = model.Tlfnr, Active = model.Active };
        }
    }
}
