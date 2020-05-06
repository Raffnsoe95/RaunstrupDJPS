using System;
using System.Collections.Generic;
using System.Text;
using Raunstrup.DataAccess;
using Raunstrup.DataAccess.Model;

namespace Raunstrup.BusinessLogic.ServiceInterfaces
{
   public interface IWorkingHoursService
    {
        IEnumerable<WorkingHours> GetAll();
        WorkingHours Get(int id);
        void Create(WorkingHours workingHours);
        void Update(WorkingHours workingHours);
        void Delete(int id);
    }
}
