using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Raunstrup.Api.Models;
using Raunstrup.Contract.DTOs;
using Raunstrup.BusinessLogic.ServiceInterfaces;

namespace Raunstrup.Api.Controllers
{
    [Produces("application/json")]
    [Route("api/Items")]
    //[ApiVersion("1.0")]
    //[ApiVersion("1.1")]
    [ApiController]

    public class ItemController : ControllerBase
    {
        private readonly IItemService _itemService;

        public ItemController(IItemService itemService)
        {
            _itemService = itemService;
        }

        // GET: api/Items
        [HttpGet]
        public IEnumerable<ItemDto> Get()
        {
            try
            {
                return _itemService.GetAll().Select(a => ItemMapper.Map(a));
            }
            catch (Exception)
            {
                throw;
            }
        }

        // GET: api/Items/5
        [HttpGet("{id}")]
        //[ApiVersion("1.1")]
        public ItemDto Get(int id)
        {
            try
            {
                return ItemMapper.Map(_itemService.Get(id));
            }
            catch (Exception)
            {
                throw;
            }
            
        }

        // POST: api/Items
        [HttpPost]
        public void Post([FromBody] ItemDto value)
        {
            try
            {
                _itemService.Create(ItemMapper.Map(value));
            }
            catch (Exception)
            {
                throw;
            }
        }

        // PUT: api/Items/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] ItemDto value)
        {
            try
            {
                _itemService.Update(ItemMapper.Map(value));
            }
            catch (Exception)
            {
                throw;
            }
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            try
            {
                _itemService.Delete(id);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPost("AddUsedProjectItemToProject", Name = "AddUsedProjectItemToProject")]
        public void AddUsedProjectItemToProject([FromBody] ProjectUsedItemDto value)
        {
            try
            {
                _itemService.CreateUsedItems(ProjectUsedItemMapper.Map(value));
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPost("AddAssignedProjectItemToProject", Name = "AddAssignedProjectItemToProject")]
        public void AddAssignedProjectItemToProject([FromBody] ProjectAssignedItemDto value)
        {
            try
            {
                _itemService.CreateAssignedItems(ProjectAssignedItemMapper.Map(value));
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpGet("search/{searchString}", Name = "GetFilteredItems")]
        public IEnumerable<ItemDto> GetFilteredCustomers(string searchString)
        {
            try
            {
                return _itemService.GetFilteredItems(searchString).Select(a => ItemMapper.Map(a));
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
