﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Raunstrup.UI.Data;
using Raunstrup.UI.Models;
using Raunstrup.UI.Services;
using Raunstrup.Contract.Services;
using Raunstrup.Contract.DTOs;
using Microsoft.CodeAnalysis;
using Microsoft.AspNetCore.Authorization;

namespace Raunstrup.UI.Controllers
{

    [Authorize(Roles = "SuperUser,User")]
    public class WorkingHoursController : Controller
    {
        private readonly IWorkingHoursService _workingHoursService;
        private readonly IProjectService _projectService;

        public WorkingHoursController(IWorkingHoursService workingHoursService, IProjectService projectService)
        {
            _workingHoursService = workingHoursService;
            _projectService = projectService;
        }

        // GET: WorkingHours
        //public async Task<IActionResult> Index()
        //{
        //    try
        //    {
        //        var WorkingHoursDtos = await _workingHoursService.GetWorkingHoursAsync().ConfigureAwait(false);
        //        return View(WorkingHoursMapper.Map(WorkingHoursDtos));

        //    }
        //    catch (Exception) {
        //        ErrorViewModel model = new ErrorViewModel { RequestId = "Kunne ikke vise oversigt" };
        //        return View("Error", model);
        //    }
        //}

        //// GET: WorkingHours/Details/5
        //public async Task<IActionResult> Details(int? id)
        //{
        //    try
        //    {
        //        if (id == null)
        //        {
        //            return NotFound();
        //        }

        //        var workingHoursViewModel = await _workingHoursService.GetWorkingHoursAsync(id.Value).ConfigureAwait(false);

        //        if (workingHoursViewModel == null)
        //        {
        //            return NotFound();
        //        }

        //        return View(WorkingHoursMapper.Map(workingHoursViewModel));
        //    }
        //    catch (Exception) {
        //        ErrorViewModel model = new ErrorViewModel { RequestId = "Kunne ikke vise detaljer" };
        //        return View("Error", model);
        //    }

        //}

        // GET: WorkingHours/Create
        public IActionResult Create(int Id)
        {
            try
            {
                var WorkingHours = new WorkingHoursViewModel { ProjectId = Id, EmployeeId = Convert.ToInt32(User.Identity.Name.Split('@')[0]) };
                return View(WorkingHours);

            }
            catch (Exception) 
            {
                ErrorViewModel model = new ErrorViewModel { RequestId = "Kunne ikke danne side" };
                return View("Error", model);
            }
        }


        // POST: WorkingHours/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(WorkingHoursViewModel workingHoursViewModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _workingHoursService.AddAsync(WorkingHoursMapper.Map(workingHoursViewModel)).ConfigureAwait(false);

                    return RedirectToAction("details", "project", new { id = workingHoursViewModel.ProjectId });
                }

                return View(workingHoursViewModel);
            }
            catch (Exception)
            {
                ErrorViewModel model = new ErrorViewModel { RequestId = "Kunne ikke indberette arbejdstimer" };
                return View("Error", model);
            }

        }

        //// GET: WorkingHours/Edit/5
        //public async Task<IActionResult> Edit(int id)
        //{
        //    try
        //    {
        //        var WorkingHoursViewModel = await _workingHoursService.GetWorkingHoursAsync(id).ConfigureAwait(false);
        //        if (WorkingHoursViewModel == null)
        //        {
        //            return NotFound();
        //        }
        //        return View(WorkingHoursMapper.Map(WorkingHoursViewModel));
        //    }
        //    catch (Exception) {
        //        ErrorViewModel model = new ErrorViewModel { RequestId = "Kunne ikke redigere arbejdstimer" };
        //        return View("Error", model);
        //    }

        //}

        //// POST: WorkingHours/Edit/5
        //// To protect from overposting attacks, enable the specific properties you want to bind to, for 
        //// more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Edit(int id, [Bind("Id,Amount,EmployeeId,HourlyPrice,ProjectId")] WorkingHoursViewModel workingHoursViewModel)
        //{
        //    try
        //    {
        //        if (id != workingHoursViewModel.WorkingHoursId)
        //        {
        //            return NotFound();
        //        }

        //        if (ModelState.IsValid)
        //        {
        //            try
        //            {
        //                _context.Update(workingHoursViewModel);
        //                await _context.SaveChangesAsync();
        //            }
        //            catch (DbUpdateConcurrencyException)
        //            {
        //                if (!WorkingHoursExists(workingHoursViewModel.WorkingHoursId))
        //                {
        //                    return NotFound();
        //                }
        //                else
        //                {
        //                    throw;
        //                }
        //            }
        //            return RedirectToAction(nameof(Index));
        //        }

        //        return View(workingHoursViewModel);
        //    }
        //    catch (Exception) {
        //        ErrorViewModel model = new ErrorViewModel { RequestId = "Kunne ikke rette arbejdstimer" };
        //        return View("Error", model);
        //    }

        //}

        //// GET: WorkingHours/Delete/5
        //public async Task<IActionResult> Delete(int? id)
        //{
        //    try
        //    {
        //        if (id == null)
        //        {
        //            return NotFound();
        //        }

        //        var workingHours = await _context.WorkingHours
        //            .Include(w => w.Employee)
        //            .FirstOrDefaultAsync(m => m.WorkingHoursId == id);
        //        if (workingHours == null)
        //        {
        //            return NotFound();
        //        }

        //        return View(workingHours);
        //    }
        //    catch (Exception) { 
            
        //    }
        //    ErrorViewModel model = new ErrorViewModel { RequestId = "Kunne ikke slette arbejdstimer" };
        //    return View("Error", model);
        //}
        
           

        //// POST: WorkingHours/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> DeleteConfirmed(int id)
        //{
        //    try
        //    {
        //        var workingHours = await _context.WorkingHours.FindAsync(id);
        //        _context.WorkingHours.Remove(workingHours);
        //        await _context.SaveChangesAsync();
        //        return RedirectToAction(nameof(Index));

        //    }
        //    catch (Exception) 
        //    {
        //        ErrorViewModel model = new ErrorViewModel { RequestId = "Kunne ikke slette arbejdstimer" };
        //        return View("Error", model);
        //    }

        //}

        //private bool WorkingHoursExists(int id)
        //{
        //    try
        //    {
        //        return _context.WorkingHours.Any(e => e.WorkingHoursId == id);

        //    }
        //    catch(Exception)
        //    { throw; }
            
        //}

        //public IActionResult AddWorkingHours(int id)
        //{
        //    try
        //    {
        //        WorkingHoursViewModel workingHours = new WorkingHoursViewModel { ProjectId = id, EmployeeId = 3 };

        //        return View(workingHours);

        //    }
        //    catch (Exception) 
        //    {
        //        ErrorViewModel model = new ErrorViewModel { RequestId = "Kunne ikke danne side" };
        //        return View("Error", model);
        //    }

        //}
    }
}

