
using Raunstrup.BusinessLogic.ServiceInterfaces;
using Raunstrup.DataAccess.Context;
using Raunstrup.DataAccess.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Raunstrup.BusinessLogic.Services
{
   public class WorkingHoursService: IWorkingHoursService
    {
        private readonly RaunstrupContext _context;

        public WorkingHoursService(RaunstrupContext context)
        {
            _context = context;
        }

        IEnumerable<WorkingHours> IWorkingHoursService.GetAll()
        {
            return _context.WorkingHours.ToList();
        }

        WorkingHours IWorkingHoursService.Get(int id)
        {
            return _context.WorkingHours.Find(id);
        }

        void IWorkingHoursService.Create(WorkingHours workingHours)
        {
            _context.WorkingHours.Add(workingHours);
            _context.SaveChanges();
        }

        void IWorkingHoursService.Update(WorkingHours workingHours)
        {
            _context.WorkingHours.Update(workingHours);
            _context.SaveChanges();
        }

        void IWorkingHoursService.Delete(int id)
        {
            _context.WorkingHours.Remove(_context.WorkingHours.Find(id));
            _context.SaveChanges();
        }

        //void IItemService.Create(ProjectItem projectItem)
        //{
        //    _context.ProjectItems.Add(projectItem);
        //    _context.SaveChanges();
        //}
    }
}
