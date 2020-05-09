using Raunstrup.Contract.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Raunstrup.Contract.Services
{
   public interface IWorkingHoursService
    {
        Task<IEnumerable<WorkingHoursDto>> GetWorkingHoursAsync();

        Task<WorkingHoursDto> GetWorkingHoursAsync(int id);

        Task AddAsync(WorkingHoursDto workingHours);

        Task UpdateAsync(int id, WorkingHoursDto workingHours);

        Task RemoveAsync(int id);
    }
}
