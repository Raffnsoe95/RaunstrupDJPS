using System;
using System.Collections.Generic;
using System.Text;
using Raunstrup.DataAccess;

namespace Raunstrup.BusinessLogic.ServiceInterfaces
{
    public interface IProjectService
    {
        
            IEnumerable<Project> GetAll();
            Project Get(int id);
            void Create(Project project);
            void Update(Project project);
            void Delete(int id);
        
    }
}
