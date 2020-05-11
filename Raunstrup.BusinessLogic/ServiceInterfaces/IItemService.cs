using Raunstrup.DataAccess.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Raunstrup.BusinessLogic.ServiceInterfaces
{
    public interface IItemService
    {
        IEnumerable<Item> GetAll();

        Item Get(int id);

        void Create(Item item);

        void Update(Item item);

        void Delete(int id);

        void CreateUsedItems(ProjectUsedItem projectUsedItem);

        void CreateAssignedItems(ProjectAssignedItem projectAssignedItem);

        //void AddDiscountToItem(Discount discount);
        
    }
}
