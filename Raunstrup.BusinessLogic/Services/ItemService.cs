
using Raunstrup.BusinessLogic.ServiceInterfaces;
using Raunstrup.DataAccess.Context;
using Raunstrup.DataAccess.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Raunstrup.BusinessLogic.Services
{
    public class ItemService : IItemService
    {
        private readonly RaunstrupContext _context;

        public ItemService(RaunstrupContext context)
        {
            _context = context;
        }

        IEnumerable<Item> IItemService.GetAll()
        {
            return _context.Items.ToList();
        }

        Item IItemService.Get(int id)
        {
            return _context.Items.Find(id);
        }

        void IItemService.Create(Item item)
        {
            _context.Items.Add(item);
            _context.SaveChanges();
        }

        void IItemService.Update(Item item)
        {
            _context.Items.Update(item);
            _context.SaveChanges();
        }

        void IItemService.Delete(int id)
        {
            _context.Items.Remove(_context.Items.Find(id));
            _context.SaveChanges();
        }

        void IItemService.Create(ProjectItem projectItem)
        {
            _context.ProjectItems.Add(projectItem);
            _context.SaveChanges();
        }
    }
}
