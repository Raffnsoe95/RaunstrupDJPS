using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Raunstrup.BusinessLogic.ServiceInterfaces;

using Raunstrup.DataAccess;
using Raunstrup.DataAccess.Context;

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
                return _context.Projects.Include(w=>w.WorkingHours).ToList();
            }

            Project IProjectService.Get(int id)
            {
                return _context.Projects.Find(id);
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

            void IProjectService.Delete(int id)
            {
                _context.Projects.Remove(_context.Projects.Find(id));
                _context.SaveChanges();
            }
        }
    }

