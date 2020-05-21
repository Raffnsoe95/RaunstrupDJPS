using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Raunstrup.UI.Models
{
    public class ProjectAssignedItemViewModel
    {
        public int Id { get; set; }

        public int Amount { get; set; }

        public decimal Price { get; set; }

        public ItemViewModel Item { get; set; }

        public int ItemId { get; set; }

        public int ProjectId { get; set; }

        public decimal Discount
        {
            get
            {
                if (Item.Discount == null || Amount < Item.Discount.Amount)
                {
                    return 0;
                }
                else
                {
                    return Math.Round((Amount * Price) * Item.Discount.DiscountPercentage / 100, 2);
                }
            }
        }

        public decimal TotalPriceWithDiscount
        {
            get
            {
                return Math.Round((Amount * Price) - Discount, 2);
            }
        }
    }
}
