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
            {
                Id = dto.Id,
                Name = dto.Name,
                Phone = dto.Phone,
                EstWorkingHours = dto.EstWorkingHours,
                Active = dto.Active,
                Specialties = SpecialtyMapper.Map(dto.Specialties).ToList(), 
                Type = TypeMapper.Map(dto.Type), 
                ManagerID = dto.ManagerID,
                Manager = EmployeeMapper.Map(dto.Manager),
                Department = DepartmentMapper.Map(dto.Department),
                RowVersion = dto.RowVersion
            };
        }

        public static IEnumerable<EmployeeDto> Map(IEnumerable<Employee> model)
        {
            return model.Select(x => Map(x)).AsEnumerable();
        }

        public static IEnumerable<Employee> Map(IEnumerable<EmployeeDto> model)
        {
            return model.Select(x => Map(x)).AsEnumerable();
        }

        public static EmployeeDto Map(Employee model)
        {
            if (model == null)
            {
                return null;
            }
            return new EmployeeDto
            { 
                Id = model.Id,
                Name = model.Name,
                Phone = model.Phone,
                EstWorkingHours = model.EstWorkingHours,
                Active = model.Active,
                Specialties = SpecialtyMapper.Map(model.Specialties).ToList(),
                Type = TypeMapper.Map(model.Type),
                ManagerID = model.ManagerID,
                Manager = EmployeeMapper.Map(model.Manager),
                Department = DepartmentMapper.Map(model.Department),
                RowVersion = model.RowVersion
            };
        }
    }
}
