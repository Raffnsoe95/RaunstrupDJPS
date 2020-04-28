using System;
using System.Collections.Generic;
using System.Text;
using Raunstrup.DataAccess;

namespace Raunstrup.BusinessLogic.ServiceInterfaces
{
    interface IProjectService
    {
        
            IEnumerable<Project> GetAll();
            Customer Get(int id);
            void Create(Project project);
            void Update(Project project);
            void Delete(int id);
        
    }
}
