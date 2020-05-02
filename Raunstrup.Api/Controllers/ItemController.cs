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
    [Route("api/Item")]
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
            return _itemService.GetAll().Select(a => ItemMapper.Map(a));
        }

        // GET: api/Items/5
        [HttpGet("{id}")]
        //[ApiVersion("1.1")]
        public ItemDto Get(int id)
        {
            return ItemMapper.Map(_itemService.Get(id));
        }

        // POST: api/Items
        [HttpPost]
        public void Post([FromBody] ItemDto value)
        {
            _itemService.Create(ItemMapper.Map(value));
        }

        // PUT: api/Items/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] ItemDto value)
        {
            _itemService.Update(ItemMapper.Map(value));
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _itemService.Delete(id);
        }
    }
}
