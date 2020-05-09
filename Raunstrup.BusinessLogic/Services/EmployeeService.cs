using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Raunstrup.BusinessLogic.ServiceInterfaces;
using Raunstrup.DataAccess;
using Raunstrup.DataAccess.Context;
using Raunstrup.DataAccess.Model;


namespace Raunstrup.BusinessLogic.Services
{
   

    public class EmployeeService : IEmployeeService
    {
        private readonly RaunstrupContext _context;

        public EmployeeService(RaunstrupContext context)
        {
            _context = context;
        }

        IEnumerable<Employee> IEmployeeService.GetAll()
        {
            return _context.Employees
            .Include(e => e.Type)
            .Include(e => e.Specialties)
            .Include(e => e.Department)
                .ToList();
        }

        Employee IEmployeeService.Get(int id)
        {
            return _context.Employees
            .Include(e => e.Type)
            .Include(e => e.Specialties)
            .Include(e => e.Manager)
            .Include(e => e.Department)
            .FirstOrDefault(x => x.Id == id);
        }

        void IEmployeeService.Create(Employee employee)
        {
            _context.Employees.Add(employee);
            _context.SaveChanges();
        }

        void IEmployeeService.Update(Employee employee)
        {
            _context.Employees.Update(employee);
            _context.SaveChanges();
        }

        void IEmployeeService.Delete(int id)
        {
            _context.Employees.Remove(_context.Employees.Find(id));
            _context.SaveChanges();
        }

        void IEmployeeService.Create(ProjectEmployee projectEmployee)
        {
            _context.ProjectEmployees.Add(projectEmployee);
            _context.SaveChanges();
        }

        void IEmployeeService.Create(ProjectDriving projectDriving)
        {

            _context.projectDrivings.Add(projectDriving);
            _context.SaveChanges();
        }
    }
}
