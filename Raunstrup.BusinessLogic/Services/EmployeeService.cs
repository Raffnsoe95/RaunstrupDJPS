﻿using System.Collections.Generic;
using System.Linq;
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
            return _context.Employees.ToList();
        }

        Employee IEmployeeService.Get(int id)
        {
            return _context.Employees.Find(id);
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
    }
}