using System;
using System.Collections.Generic;
using System.Text;
using Raunstrup.DataAccess;

namespace Raunstrup.BusinessLogic.ServiceInterfaces
{
    public interface IProjectService
    { 
        IEnumerable<Project> GetAll();

        IEnumerable<Project> GetAll(int employeeId);

        Project Get(int id);

        void Create(Project project);

        void Update(Project project);

        void Delete(int id);

        void AddCustomerToProject(Project project);

        IEnumerable<Project> GetProjectsByCustomerId(int customerId);

        IEnumerable<Project> GetProjectsByEmployeeId(int employeeId);
    }
}
