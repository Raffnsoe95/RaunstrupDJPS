using System;
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

namespace Raunstrup.UI.Controllers
{
    public class ProjectController : Controller
    {
        private readonly ViewModelContext _context;
        private readonly IProjectService _projectService;

        public ProjectController(ViewModelContext context, IProjectService projectService)
        {
            _context = context;
            _projectService = projectService;
        }

        // GET: Project
        public async Task<IActionResult> Index()
        {
            var projectDtos = await _projectService.GetProjectAsync().ConfigureAwait(false);
            return View(ProjectMapper.Map(projectDtos));
            //return View(await _context.Projects.ToListAsync());
        }

        // GET: Project/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var projectViewModel = await _projectService.GetProjectAsync(id.Value).ConfigureAwait(false);

            if (projectViewModel == null)
            {
                return NotFound();
            }

            return View(ProjectMapper.Map(projectViewModel));
        }

        // GET: Project/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Project/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,StartDate,EndDate,Price,Description,Active,IsFixedPrice,IsAccepted,IsDone,Rowversion")] ProjectViewModel projectViewModel)
        {
            if (ModelState.IsValid)
            {
                await _projectService.AddAsync(ProjectMapper.Map(projectViewModel)).ConfigureAwait(false);

                return RedirectToAction(nameof(Index));

                //_context.Add(projectViewModel);
                //await _context.SaveChangesAsync();
                //return RedirectToAction(nameof(Index));
            }
            return View(projectViewModel);
        }

        // GET: Project/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            //if (id == null)
            //{
            //    return NotFound();
            //}

            var projectViewModel = await _projectService.GetProjectAsync(id).ConfigureAwait(false);
            if (projectViewModel == null)
            {
                return NotFound();
            }
            return View(ProjectMapper.Map(projectViewModel));
        }

        // POST: Project/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,StartDate,EndDate,Price,Description,Active,IsFixedPrice,IsAccepted,IsDone,Rowversion")] ProjectViewModel projectViewModel)
        {
            if (id != projectViewModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _projectService.UpdateAsync(id, ProjectMapper.Map(projectViewModel)).ConfigureAwait(false);
                    return RedirectToAction(nameof(Index));
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProjectViewModelExists(projectViewModel.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
            }
            return View(projectViewModel);
        }

        // GET: Project/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var projectViewModel = await _projectService.GetProjectAsync(id.Value).ConfigureAwait(false);
            if (projectViewModel == null)
            {
                return NotFound();
            }

            return View(ProjectMapper.Map(projectViewModel));
        }

        // POST: Project/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _projectService.RemoveAsync(id).ConfigureAwait(false);

            return RedirectToAction(nameof(Index));
        }

        private bool ProjectViewModelExists(int id)
        {
            return _context.Projects.Any(e => e.Id == id);
        }
    }
}
