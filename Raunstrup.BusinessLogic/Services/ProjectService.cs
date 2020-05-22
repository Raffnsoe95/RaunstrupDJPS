using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using Raunstrup.BusinessLogic.ServiceInterfaces;

using Raunstrup.DataAccess;
using Raunstrup.DataAccess.Context;
using Raunstrup.DataAccess.Model;

namespace Raunstrup.BusinessLogic.Services
{
    public class ProjectService : IProjectService
    {
       
        private readonly RaunstrupContext _context;

            public ProjectService(RaunstrupContext context)
            {
                _context = context;
            }

            IEnumerable<Project> IProjectService.GetAll()
            {
                return _context.Projects.Where( p => p.Active == true)
                .Include(w => w.WorkingHours)
                .ThenInclude(e => e.Employee)
                .Include(w => w.ProjectDrivings)
                .ThenInclude(e => e.Employee)
                .Include(w => w.ProjectEmployees)
                .ThenInclude(e => e.Employee)
                .Include(w => w.UsedItems)
                .ThenInclude(e => e.Item)
                .Include(w => w.AssignedItems)
                .ThenInclude(e => e.Item)
                .Include(w => w.Customer)
                .ToList();
            //
            }

        IEnumerable<Project> IProjectService.GetAll(int employeeId)
        {
            return _context.Projects.Where(e => e.ProjectEmployees.Any(f => f.EmployeeID == employeeId) && e.Active)
                .Include(w => w.WorkingHours)
                .ThenInclude(e => e.Employee)
                .Include(w => w.ProjectDrivings)
                .ThenInclude(e => e.Employee)
                .Include(w => w.ProjectEmployees)
                .ThenInclude(e => e.Employee)
                .Include(w => w.UsedItems)
                .ThenInclude(e => e.Item)
                .Include(w => w.AssignedItems)
                .ThenInclude(e => e.Item)
                .Include(w => w.Customer)
                .ToList();
        }

        Project IProjectService.Get(int id)
            {
            return _context.Projects
            .Include(w => w.WorkingHours)
            .ThenInclude(e => e.Employee).ThenInclude(e => e.Type)
            .Include(w => w.WorkingHours)
            .ThenInclude(e => e.Employee).ThenInclude(e => e.Specialty)
            .Include(w => w.ProjectDrivings)
            .ThenInclude(e => e.Employee)
            .Include(w => w.ProjectEmployees)
            .ThenInclude(e => e.Employee).ThenInclude(e => e.Type)
            .Include(w => w.ProjectEmployees)
            .ThenInclude(e => e.Employee).ThenInclude(e => e.Specialty)
            .Include(w => w.UsedItems)
            .ThenInclude(e => e.Item).ThenInclude(e => e.Discount)
            .Include(w => w.AssignedItems)
            .ThenInclude(e => e.Item).ThenInclude(e => e.Discount)
            .Include(w=> w.Customer).ThenInclude(e => e.CustomerDiscountType)
            .FirstOrDefault(x => x.Id == id);
        }

            void IProjectService.Create(Project project)
            {
                _context.Projects.Add(project);
                _context.SaveChanges();
            }

        void IProjectService.Update(Project project)
        {
            try 
            {
                _context.Projects.Update(project);
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException dbu)
            {
                var exceptionEntry = dbu.Entries.Single();
                var databaseEntry = exceptionEntry.GetDatabaseValues();
                project = (Project)databaseEntry.ToObject();

                dbu.Data.Add("dbvalue", project);
                throw;
            }
        }

        void IProjectService.Delete(int id)
        {
            Project tmpProject = _context.Projects.Find(id);
            tmpProject.Active = false;
            _context.Projects.Update(tmpProject);
            _context.SaveChanges();
        }

        void IProjectService.AddCustomerToProject(Project project)
        {
            Project tempProject =
                 _context.Projects
                .Include(w => w.WorkingHours)
                .ThenInclude(e => e.Employee)
                .Include(w => w.ProjectDrivings)
                .ThenInclude(e => e.Employee)
                .Include(w => w.ProjectEmployees)
                .ThenInclude(e => e.Employee)
                .Include(w => w.UsedItems)
                .ThenInclude(e => e.Item)
                .Include(w => w.AssignedItems)
                .ThenInclude(e => e.Item)
                .Include(w => w.Customer)
                .FirstOrDefault(x => x.Id == project.Id);
            tempProject.CustomerID = project.CustomerID;
            _context.Projects.Update(tempProject);
            _context.SaveChanges();
        }

        IEnumerable<Project> IProjectService.GetProjectsByCustomerId(int customerID)
        {
            return _context.Projects
                .Where(c => c.CustomerID == customerID);
                
        }
       
    }
}

