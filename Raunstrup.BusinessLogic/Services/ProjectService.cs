﻿using System;
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
                return _context.Projects
                .Include(w=>w.WorkingHours)
                .ThenInclude(e=>e.Employee)
                .Include(w => w.ProjectDrivings)
                .ThenInclude(e=>e.Employee)
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
            .ThenInclude(e => e.Employee)
            .Include(w => w.ProjectDrivings)
            .ThenInclude(e => e.Employee)
            .Include(w => w.ProjectEmployees)
            .ThenInclude(e => e.Employee)
            .Include(w => w.UsedItems)
            .ThenInclude(e => e.Item)
            .Include(w => w.AssignedItems)
            .ThenInclude(e => e.Item)
            .Include(w=> w.Customer)
            

                .FirstOrDefault(x => x.Id == id);

            }

            void IProjectService.Create(Project project)
            {
                _context.Projects.Add(project);
                _context.SaveChanges();
            }

            void IProjectService.Update(Project project)
            {

                _context.Projects.Update(project);
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
            tempProject.CustomerId = project.CustomerId;
            _context.Projects.Update(tempProject);
            _context.SaveChanges();
        }

        void IProjectService.Delete(int id)
            {
                _context.Projects.Remove(_context.Projects.Find(id));
                _context.SaveChanges();
            }

        //IEnumerable<WorkingHours> GetWorkingHoursfromProject(Project project)
        //{
        //    return _context.WorkingHours.Where(p => p.ProjectId == project.Id);

        //}
    }
}

