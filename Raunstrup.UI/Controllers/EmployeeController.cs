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
using Microsoft.AspNetCore.Authorization;
using Microsoft.CodeAnalysis;

namespace Raunstrup.UI.Controllers
{
    [Authorize(Roles = "SuperUser")]
    public class EmployeeController : Controller
    {
        private readonly IEmployeeservice _employeeService;
        private readonly IProjectService _projectService;

        public EmployeeController(IEmployeeservice employeeService, IProjectService projectService)
        {
            _employeeService = employeeService;
            _projectService = projectService;
        }
        // GET: Employee
        public async Task<IActionResult> Index(string searchString)
        {
            try
            {
                IEnumerable<EmployeeDto> employeeDtos = await _employeeService.GetChosenEmployees(searchString);
                return View(EmployeeMapper.Map(employeeDtos));

            }
            catch (Exception)
            {
                ErrorViewModel model = new ErrorViewModel { RequestId = "Søgningen kunne ikke gennemføres" };
                return View("Error", model);
            }


        }
        // GET: Employee/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            try
            {
                if (id == null)
                {
                    return NotFound();
                }
                var employeeViewModel = await _employeeService.GetEmployeeAsync(id.Value).ConfigureAwait(false);
                //////var employeeViewModel = await _context.Employees
                //////    .FirstOrDefaultAsync(m => m.Id == id);
                if (employeeViewModel == null)
                {
                    return NotFound();
                }
                EmployeeDetailsViewModel employeeDetailsViewModel = EmployeeDetailsMapper.Map(employeeViewModel);


                IEnumerable<ProjectDto> Projects = await _projectService.GetProjectsByEmployeeId(id.Value);


                employeeDetailsViewModel.Projects = ProjectMapper.Map(Projects);

                return View(employeeDetailsViewModel);
            }
            catch (Exception)
            {
                ErrorViewModel model = new ErrorViewModel { RequestId = "Medarbejderen kunne ikke vises" };
                return View("Error", model);
            }
        }
        // GET: Employee/Create
        public IActionResult Create()
        {
            try
            {
                return View();
            }
            catch { throw; }
        }
        // POST: Employee/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]

        //------------------------------------
        [Authorize(Roles = "SuperUser")]
        //-----------------------------
        public async Task<IActionResult> Create([Bind("Id,Name,Phone,Salary,Active")] EmployeeViewModel employeeViewModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _employeeService.AddAsync(EmployeeMapper.Map(employeeViewModel)).ConfigureAwait(false);

                    return RedirectToAction(nameof(Index));
                    //_context.Add(employeeViewModel);
                    //await _context.SaveChangesAsync();
                    //return RedirectToAction(nameof(Index));
                }
                return View(employeeViewModel);
            }
            catch (Exception)
            {
                ErrorViewModel model = new ErrorViewModel { RequestId = "Medarbejderen kunne ikke oprettes" };
                return View("Error", model);
            }
        }
        // GET: Employee/Edit/5
        //public async Task<IActionResult> Edit(int? id)
        //{
        //    try
        //    {

        //        //if (id == null)
        //        //{
        //        //    return NotFound();
        //        //}

        //        var employeeViewModel = await _context.Employees.FindAsync(id);
        //        if (employeeViewModel == null)
        //        {
        //            return NotFound();
        //        }
        //        return View(employeeViewModel);
        //    }
        //    catch (Exception){ throw; }
        //}

        //    var employeeViewModel = await _context.Employees.FindAsync(id);
        //    if (employeeViewModel == null)
        //    {
        //        return NotFound();
        //    }
        //    return View(employeeViewModel);
        //}

        // POST: Employee/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Phone,Salary,Active")] EmployeeViewModel employeeViewModel)
        //{
        //    try
        //    {
        //        if (id != employeeViewModel.Id)
        //        {
        //            return NotFound();
        //        }

        //        if (ModelState.IsValid)
        //        {
        //            try
        //            {
        //                await _employeeService.UpdateAsync(id, EmployeeMapper.Map(employeeViewModel)).ConfigureAwait(false);
        //                return RedirectToAction(nameof(Index));
        //            }
        //            catch (DbUpdateConcurrencyException)
        //            {
        //                if (!EmployeeViewModelExists(employeeViewModel.Id))
        //                {
        //                    return NotFound();
        //                }
        //                else
        //                {
        //                    throw;
        //                }
        //            }
        //        }
        //        return View(employeeViewModel);
        //    }
        //    catch (Exception) { throw; }
            
        //}

        // GET: Employee/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            try
            {
                if (id == null)
                {
                    return NotFound();
                }

                var employeeViewModel = await _employeeService.GetEmployeeAsync(id.Value).ConfigureAwait(false);
                if (employeeViewModel == null)
                {
                    return NotFound();
                }

                return View(employeeViewModel);
            }
            catch (Exception)
            {
                ErrorViewModel model = new ErrorViewModel { RequestId = "Medarbejderen kunne ikke slettes" };
                return View("Error", model);
            }
        }
        // POST: Employee/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            try
            {
                await _employeeService.RemoveAsync(id).ConfigureAwait(false);

                return RedirectToAction(nameof(Index));

            }
            catch (Exception) 
            {
                ErrorViewModel model = new ErrorViewModel { RequestId = "Medarbejderen kunne ikke slettes" };
                return View("Error", model);
            }
        }

        //private bool EmployeeViewModelExists(int id)
        //{
        //    try
        //    {
        //        return _context.Employees.Any(e => e.Id == id);

        //    }
        //    catch (Exception) { throw; }
        //}
        // GET: Employee 
        public async Task<IActionResult> AddProjectEmployee(int id, string searchString)
        {
            try
            {
                IEnumerable<EmployeeDto> employeeDtos = await _employeeService.GetChosenEmployees(searchString);
                var projects = EmployeeMapper.MapEst(employeeDtos).Select(x => { x.ProjectId = id; return x; }).ToList();
                return View(EmployeeMapper.MapEst(employeeDtos).Select(x => { x.ProjectId = id; return x; }).ToList());

            }
            catch (Exception)
            {
                ErrorViewModel model = new ErrorViewModel { RequestId = "Medarbejderen kunne ikke vises" };
                return View("Error", model);
            }
        }
        public async Task<IActionResult> AddProjectEmployees(int id)
        {
            try
            {
                var employeeDtos = await _employeeService.GetEmployeeAsync().ConfigureAwait(false);


                return View(EmployeeMapper.MapEst(employeeDtos).Select(x => { x.ProjectId = id; return x; }).ToList());

            }
            catch (Exception) 
            {
                ErrorViewModel model = new ErrorViewModel { RequestId = "Medarbejderen kunne ikke tilknyttes projektet" };
                return View("Error", model);
            }
        }
        public async Task<IActionResult> AddProjectEmployeeToProject(List<EstWorkingHoursEmployeeViewModel> items)
        {
            try
            {
                var projectEmployees = items.Where(x => x.EstWorkingHours > 0).Select(x => new ProjectEmployeeViewModel()
                {
                    EmployeeId = x.Id,
                    ProjectId = x.ProjectId,
                    EstWorkingHours = x.EstWorkingHours,

                });
                await _employeeService.AddProjectEmployeeAsync(ProjectEmployeeMapper.Map(projectEmployees).ToList()).ConfigureAwait(false);

                return RedirectToAction("details", "project", new { id = items[0].ProjectId });
            }
            catch (Exception) 
            {
                ErrorViewModel model = new ErrorViewModel { RequestId = "Medarbejderen kunne ikke tilknyttes projektet" };
                return View("Error", model);
            }
        }
    }
} 

