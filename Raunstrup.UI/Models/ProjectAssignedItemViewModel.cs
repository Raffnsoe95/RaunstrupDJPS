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

        public int Discount
        {
            get
            {
                if (Item.Discount == null || Amount < Item.Discount.Amount)
                {
                    return 0;
                }
                else
                {
                    return Item.Discount.DiscountPercentage;
                }
            }
        }

        public decimal TotalPriceWithDiscount
        {
            get
            {
                return (Amount * Price) * (100 - Discount) / 100;
            }
        }
    }
}
