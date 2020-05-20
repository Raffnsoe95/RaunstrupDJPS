using Raunstrup.Contract.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;


namespace Raunstrup.Contract.Services
{
    public interface IProjectService
    {
        Task<IEnumerable<ProjectDto >> GetProjectAsync(string userName, string userRole);

        Task<ProjectDto> GetProjectAsync(int id);

        Task AddAsync(ProjectDto project);

        Task UpdateAsync(int id, ProjectDto project);

        Task RemoveAsync(int id);

        Task<IEnumerable<ProjectDto>> GetProjectsByCustomerId(int customerId);

        Task<IEnumerable<ProjectDto>> GetProjectsByEmployeeId(int employeeId);
    }
}
