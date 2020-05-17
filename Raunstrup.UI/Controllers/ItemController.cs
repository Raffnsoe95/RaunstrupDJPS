using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Raunstrup.Contract.DTOs;
using Raunstrup.Contract.Services;
using Raunstrup.UI.Data;
using Raunstrup.UI.Models;
using Microsoft.AspNetCore.Authorization;

namespace Raunstrup.UI.Controllers
{
    public class ItemController : Controller
    {
        private readonly ViewModelContext _context;

        private readonly IItemService _itemService;

        public ItemController(ViewModelContext context, IItemService itemService)
        {
            _context = context;
            _itemService = itemService;
        }

        [Authorize(Roles = "Admin,SuperUser")]
        // GET: Item
        public async Task<IActionResult> Index(string searchString)
        {
            var itemsDtos = await _itemService.GetChosenItems(searchString).ConfigureAwait(false);
            return View(ItemMapper.Map(itemsDtos));

        }

        // GET: Item/Details/5
        //public async Task<IActionResult> Details(int? id)
        //{
        //    if (id == null) return NotFound();

        //    var item = await _itemService.GetItemAsync(id.Value).ConfigureAwait(false);

        //    if (item == null) return NotFound();

        //    return View(ItemMapper.Map(item));
        //}

        //// GET: Item/Create
        //public IActionResult Create()
        //{
        //    return View();
        //}

        //// POST: Item/Create
        //// To protect from overposting attacks, enable the specific properties you want to bind to, for 
        //// more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Create([Bind("Id,Name,Price,Active")]
        //    ItemViewModel item)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        await _itemService.AddAsync(ItemMapper.Map(item)).ConfigureAwait(false);

        //        return RedirectToAction(nameof(Index));
        //    }

        //    return View(item);
        //}

        //// GET: Item/Edit/5
        //public async Task<IActionResult> Edit(int? id)
        //{
        //    if (id == null) return NotFound();

        //    var item = await _itemService.GetItemAsync(id.Value).ConfigureAwait(false);
        //    if (item == null) return NotFound();
        //    return View(ItemMapper.Map(item));
        //}

        //// POST: Item/Edit/5
        //// To protect from overposting attacks, enable the specific properties you want to bind to, for 
        //// more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Price,Active")]ItemViewModel item)
        //{
        //    if (id != item.Id) return NotFound();

        //    if (ModelState.IsValid)
        //    {
        //        await _itemService.UpdateAsync(id, ItemMapper.Map(item)).ConfigureAwait(false);
        //        return RedirectToAction(nameof(Index));
        //    }

        //    return View(item);
        //}

        //// GET: Item/Delete/5
        //public async Task<IActionResult> Delete(int? id)
        //{
        //    if (id == null) return NotFound();

        //    var item = await _itemService.GetItemAsync(id.Value).ConfigureAwait(false);
        //    if (item == null) return NotFound();

        //    return View(ItemMapper.Map(item));
        //}

        //// POST: Item/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> DeleteConfirmed(int id)
        //{
        //    await _itemService.RemoveAsync(id).ConfigureAwait(false);

        //    return RedirectToAction(nameof(Index));
        //}

        //private bool ItemViewModelExists(int id)
        //{
        //    return _context.Items.Any(e => e.Id == id);
        //}

        [Authorize(Roles = "Admin,SuperUser")]
        public async Task<IActionResult> AddAssignedProjectItem(int id, string searchString)
        {
            var itemDtos = await _itemService.GetChosenItems(searchString).ConfigureAwait(false);
            var items = ItemMapper.Map(itemDtos).Select(x => { x.projectID = id; return x; }).ToList();
            return View(ItemMapper.Map(itemDtos).Select(x => { x.projectID = id; return x; }).ToList());

            //if (!String.IsNullOrEmpty(searchString))
            //{
            //    var filteredItemDtos = await _itemService.GetFilteredItemsAsync(searchString).ConfigureAwait(false);
            //    var items = ItemMapper.Map(filteredItemDtos).Select(x => { x.projectID = id; return x; }).ToList();
            //    return View(ItemMapper.Map(filteredItemDtos).Select(x => { x.projectID = id; return x; }).ToList());

            //}
            //else
            //{
            //    var itemDtos = await _itemService.GetItemsAsync().ConfigureAwait(false);
            //    var items = ItemMapper.Map(itemDtos).Select(x => { x.projectID = id; return x; }).ToList();
            //    return View(ItemMapper.Map(itemDtos).Select(x => { x.projectID = id; return x; }).ToList());

            //}
        }

        [Authorize(Roles = "Admin,SuperUser")]
        public async Task<IActionResult> AddAssignedProjectItemToProject(List<ItemViewModel> items)
        {
            var projectItems = items.Where(x => x.Amount > 0).Select(x => new ProjectAssignedItemViewModel() 
            { 
                Amount = x.Amount, 
                Price = x.Price, 
                ProjectId = x.projectID, 
                ItemId = x.Id,  
            });

            await _itemService.AddAssignedItemAsync(ProjectAssignedItemMapper.Map(projectItems).ToList()).ConfigureAwait(false);
          
            return RedirectToAction("AddAssignedProjectItem", new { id = items[0].projectID });
        }

        [Authorize(Roles = "Admin,SuperUser,User")]
        public async Task<IActionResult> AddUsedProjectItem(int id, string searchString)
        {
            var itemDtos = await _itemService.GetChosenItems(searchString).ConfigureAwait(false);
            var items = ItemMapper.Map(itemDtos).Select(x => { x.projectID = id; return x; }).ToList();
            return View(ItemMapper.Map(itemDtos).Select(x => { x.projectID = id; return x; }).ToList());

            //if (!String.IsNullOrEmpty(searchString))
            //{
            //    var filteredItemDtos = await _itemService.GetFilteredItemsAsync(searchString).ConfigureAwait(false);
            //    var items = ItemMapper.Map(filteredItemDtos).Select(x => { x.projectID = id; return x; }).ToList();
            //    return View(ItemMapper.Map(filteredItemDtos).Select(x => { x.projectID = id; return x; }).ToList());

            //}
            //else
            //{
            //    var itemDtos = await _itemService.GetItemsAsync().ConfigureAwait(false);
            //    var items = ItemMapper.Map(itemDtos).Select(x => { x.projectID = id; return x; }).ToList();
            //    return View(ItemMapper.Map(itemDtos).Select(x => { x.projectID = id; return x; }).ToList());

            //}
        }

        [Authorize(Roles = "Admin,SuperUser,User")]
        public async Task<IActionResult> AddUsedProjectItemToProject(List<ItemViewModel> items)
        {
            var projectItems = items.Where(x => x.Amount > 0).Select(x => new ProjectUsedItemViewModel() 
            {   Amount = x.Amount, 
                Price = x.Price, 
                ProjectId = x.projectID, 
                ItemId = x.Id,
              
                
            });

            if (ModelState.IsValid)
            {
                await _itemService.AddUsedItemAsync(ProjectUsedItemMapper.Map(projectItems).ToList()).ConfigureAwait(false);
            }
            return RedirectToAction("AddUsedProjectItem", new { id = items[0].projectID });
        }
    }
}
