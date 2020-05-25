using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Raunstrup.UI.Data;
using Raunstrup.UI.Models;
using Raunstrup.Contract.Services;
using Microsoft.AspNetCore.Authorization;

namespace Raunstrup.UI.Controllers
{

    [Authorize(Roles = "SuperUser,User")]
    public class ProjectDrivingController : Controller
    {
        private readonly ViewModelContext _context;
        private readonly IEmployeeservice _employeeService;

        public ProjectDrivingController(ViewModelContext context, IEmployeeservice employeeService)
        {
            _context = context;
            _employeeService = employeeService;
        }

        // GET: ProjectDriving
        //public async Task<IActionResult> Index()
        //{
        //    var viewModelContext = _context.projectDrivings.Include(p => p.Employee);
        //    return View(await viewModelContext.ToListAsync());
        //}

        //// GET: ProjectDriving/Details/5
        //public async Task<IActionResult> Details(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var projectDrivingViewModel = await _context.projectDrivings
        //        .Include(p => p.Employee)
        //        .FirstOrDefaultAsync(m => m.Id == id);
        //    if (projectDrivingViewModel == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(projectDrivingViewModel);
        //}

        //GET: ProjectDriving/Create
        public IActionResult Create(int id)
        {
            //ViewData["EmployeeId"] = new SelectList(_context.Employees, "Id", "Id");

            var projectDriving = new ProjectDrivingViewModel { ProjectId = id, EmployeeId = Convert.ToInt32(User.Identity.Name.Split('@')[0])};
            return View(projectDriving);
        }

        // POST: ProjectDriving/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Amount,EmployeeId,UnitPrice,ProjectId")] ProjectDrivingViewModel projectDrivingViewModel)
        {
            if (ModelState.IsValid)
            {
                //_context.Add(projectDrivingViewModel);
                //await _context.SaveChangesAsync();
                await _employeeService.AddAsync(ProjectDrivingMapper.Map(projectDrivingViewModel));
                return RedirectToAction("details", "project", new { id = projectDrivingViewModel.ProjectId });
            }
            ViewData["EmployeeId"] = new SelectList(_context.Employees, "Id", "Id", projectDrivingViewModel.EmployeeId);
            return View(projectDrivingViewModel);
        }

        //// GET: ProjectDriving/Edit/5
        //public async Task<IActionResult> Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var projectDrivingViewModel = await _context.projectDrivings.FindAsync(id);
        //    if (projectDrivingViewModel == null)
        //    {
        //        return NotFound();
        //    }
        //    ViewData["EmployeeId"] = new SelectList(_context.Employees, "Id", "Id", projectDrivingViewModel.EmployeeId);
        //    return View(projectDrivingViewModel);
        //}

        //// POST: ProjectDriving/Edit/5
        //// To protect from overposting attacks, enable the specific properties you want to bind to, for 
        //// more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Edit(int id, [Bind("Id,Amount,EmployeeId,UnitPrice,ProjectId")] ProjectDrivingViewModel projectDrivingViewModel)
        //{
        //    if (id != projectDrivingViewModel.Id)
        //    {
        //        return NotFound();
        //    }

        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            _context.Update(projectDrivingViewModel);
        //            await _context.SaveChangesAsync();
        //        }
        //        catch (DbUpdateConcurrencyException)
        //        {
        //            if (!ProjectDrivingViewModelExists(projectDrivingViewModel.Id))
        //            {
        //                return NotFound();
        //            }
        //            else
        //            {
        //                throw;
        //            }
        //        }
        //        return RedirectToAction(nameof(Index));
        //    }
        //    ViewData["EmployeeId"] = new SelectList(_context.Employees, "Id", "Id", projectDrivingViewModel.EmployeeId);
        //    return View(projectDrivingViewModel);
        //}

        //// GET: ProjectDriving/Delete/5
        //public async Task<IActionResult> Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var projectDrivingViewModel = await _context.projectDrivings
        //        .Include(p => p.Employee)
        //        .FirstOrDefaultAsync(m => m.Id == id);
        //    if (projectDrivingViewModel == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(projectDrivingViewModel);
        //}

        //// POST: ProjectDriving/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> DeleteConfirmed(int id)
        //{
        //    var projectDrivingViewModel = await _context.projectDrivings.FindAsync(id);
        //    _context.projectDrivings.Remove(projectDrivingViewModel);
        //    await _context.SaveChangesAsync();
        //    return RedirectToAction(nameof(Index));
        //}

        //private bool ProjectDrivingViewModelExists(int id)
        //{
        //    return _context.projectDrivings.Any(e => e.Id == id);
        //}
    }
}
