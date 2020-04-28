using System.Collections.Generic;
using System.Threading.Tasks;
using Raunstrup.Contract.DTOs;

namespace Raunstrup.Contract.Services
{
    public interface IEmployeeservices
    {
        Task<IEnumerable<EmployeeDto>> GetEmployeesAsync();
        Task<EmployeeDto> GetEmployeesAsync(int id);
        Task AddAsync(EmployeeDto employee);
        Task UpdateAsync(int id, EmployeeDto employee);
        Task RemoveAsync(int id);
    }
}
