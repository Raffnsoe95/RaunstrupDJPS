using System.Collections.Generic;
using System.Linq;
using Raunstrup.Contract.DTOs;

namespace Raunstrup.UI.Models
{
    public class EmployeeMapper
    {
        public static EmployeeViewModel Map(EmployeeDto dto)
        {
            return new EmployeeViewModel
            { Id = dto.Id, Name = dto.Name, Tlfnr = dto.Tlfnr, Salary = dto.Salary, Active = dto.Active };
        }

        public static IEnumerable<EmployeeDto> Map(IEnumerable<EmployeeViewModel> model)
        {
            return model.Select(x => Map(x)).AsEnumerable();
        }

        public static EmployeeDto Map(EmployeeViewModel model)
        {
            return new EmployeeDto
            { Id = model.Id, Name = model.Name, Tlfnr = model.Tlfnr, Salary = model.Salary, Active = model.Active };
        }
    }
}
