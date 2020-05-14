using Raunstrup.Contract.DTOs;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Raunstrup.Contract.Services
{
    public interface IEmployeeservice
    {
        Task<IEnumerable<EmployeeDto>> GetEmployeesAsync();

        Task<EmployeeDto> GetEmployeesAsync(int id);

        Task AddAsync(EmployeeDto employee);

        Task UpdateAsync(int id, EmployeeDto employee);

        Task RemoveAsync(int id);

        Task AddAsync(int id, int projectid);

        Task AddProjectEmployeeAsync(List<ProjectEmployeeDto> items);

        Task AddAsync(ProjectDrivingDto projectDriving);

       Task <IEnumerable<EmployeeDto>> GetFilteredEmployeesAsync(string searchString);
    }
}
