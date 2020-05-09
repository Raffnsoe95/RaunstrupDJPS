using Raunstrup.Contract.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;


namespace Raunstrup.Contract.Services
{
   public interface IProjectService
    {
        Task<IEnumerable<ProjectDto >> GetProjectAsync();

        Task<ProjectDto> GetProjectAsync(int id);

        Task AddAsync(ProjectDto project);

        Task UpdateAsync(int id, ProjectDto project);

        Task RemoveAsync(int id);
    }
}
