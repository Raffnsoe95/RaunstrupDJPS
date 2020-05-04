using Raunstrup.Contract;
using Raunstrup.Contract.DTOs;
using Raunstrup.DataAccess;
using Raunstrup.DataAccess.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Raunstrup.Api.Models
{
    public static class EmployeeMapper
    {
        public static Employee Map(EmployeeDto dto)
        {
            if(dto==null)
            {
                return null;
            }
            return new Employee
            { Id = dto.Id, Name = dto.Name, Tlfnr = dto.Tlfnr, Active = dto.Active };
        }

        public static IEnumerable<EmployeeDto> Map(IEnumerable<Employee> model)
        {
            return model.Select(x => Map(x)).AsEnumerable();
        }

        public static EmployeeDto Map(Employee model)
        {
            return new EmployeeDto
            { Id = model.Id, Name = model.Name, Tlfnr = model.Tlfnr, Active = model.Active };
        }
    }
}
