using System.Collections.Generic;
using System.Threading.Tasks;
using Raunstrup.Contract.DTOs;
using Raunstrup.DataAccess.Model;



namespace Raunstrup.BusinessLogic.ServiceInterfaces
{
    public interface IEmployeeService
    {
        IEnumerable<Employee> GetAll();
        Employee Get(int id);
        void Create(Employee employee);
        void Update(Employee employee);
        void Delete(int id);
        void Create(ProjectEmployee projectEmployee);
        void Create(ProjectDriving projectDriving);
    }
}
