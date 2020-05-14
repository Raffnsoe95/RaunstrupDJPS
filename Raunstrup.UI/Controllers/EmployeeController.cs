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

namespace Raunstrup.UI
{
    public class EmployeeController : Controller
    {
        private readonly ViewModelContext _context;
        private readonly IEmployeeservice _employeeService;

        public EmployeeController(ViewModelContext context, IEmployeeservice employeeService)
        {
            _context = context;
            _employeeService = employeeService;

        }

        // GET: Employee
        public async Task<IActionResult> Index(string searchString)
        {
            if (!String.IsNullOrEmpty(searchString))
            {
                var filteredEmployeeDtos = await _employeeService.GetFilteredEmployeesAsync(searchString).ConfigureAwait(false);
                return View(EmployeeMapper.Map(filteredEmployeeDtos));
            }
            else
            {
                var employeeDtos = await _employeeService.GetEmployeesAsync().ConfigureAwait(false);
                return View(EmployeeMapper.Map(employeeDtos));
            }
            

         

           
        }

        // GET: Employee/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var employeeDto = await _employeeService.GetEmployeesAsync(id.Value).ConfigureAwait(false);
            //////var employeeViewModel = await _context.Employees
            //////    .FirstOrDefaultAsync(m => m.Id == id);
            if (employeeDto == null)
            {
                return NotFound();
            }

            return View(EmployeeMapper.Map(employeeDto));
        }

        // GET: Employee/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Employee/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]

        //------------------------------------
        [Authorize(Roles = "Admin,SuperUser")]
        //-----------------------------
        public async Task<IActionResult> Create([Bind("Id,Name,Phone,Salary,Active")] EmployeeViewModel employeeViewModel)
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

        // GET: Employee/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            //if (id == null)
            //{
            //    return NotFound();
            //}

            var employeeViewModel = await _context.Employees.FindAsync(id);
            if (employeeViewModel == null)
            {
                return NotFound();
            }
            return View(employeeViewModel);
        }

        // POST: Employee/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Phone,Salary,Active")] EmployeeViewModel employeeViewModel)
        {
            if (id != employeeViewModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _employeeService.UpdateAsync(id, EmployeeMapper.Map(employeeViewModel)).ConfigureAwait(false);
                    return RedirectToAction(nameof(Index));
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EmployeeViewModelExists(employeeViewModel.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
            }
            return View(employeeViewModel);
        }

        // GET: Employee/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employeeViewModel = await _employeeService.GetEmployeesAsync(id.Value).ConfigureAwait(false);
            if (employeeViewModel == null)
            {
                return NotFound();
            }

            return View(employeeViewModel);
        }

        // POST: Employee/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _employeeService.RemoveAsync(id).ConfigureAwait(false);

            return RedirectToAction(nameof(Index));
        }

        private bool EmployeeViewModelExists(int id)
        {
            return _context.Employees.Any(e => e.Id == id);
        }
        // GET: Employee
        public async Task<IActionResult> AddProjectEmployee(int id, string searchString)
        {
            if (!String.IsNullOrEmpty(searchString))
            {
                var filterdEmployeeDtos = await _employeeService.GetFilteredEmployeesAsync(searchString).ConfigureAwait(false);
                return View(EmployeeMapper.Map(filterdEmployeeDtos));
            }
            else
            {
                var employeeDtos = await _employeeService.GetEmployeesAsync().ConfigureAwait(false);
                return View(EmployeeMapper.Map(employeeDtos));
            }

           
        }
        public async Task<IActionResult> AddProjectEmployeeToProject(int id, int projectid)
        {
            if (ModelState.IsValid)
            {
                await _employeeService.AddAsync(id,projectid).ConfigureAwait(false);

                
                //_context.Add(employeeViewModel);
                //await _context.SaveChangesAsync();
                //return RedirectToAction(nameof(Index));
            }
            return RedirectToAction("AddProjectEmployee",new {id=projectid});
        }
        

    }
}
