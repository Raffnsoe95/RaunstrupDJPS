using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Raunstrup.UI.Models
{
    public class ItemViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }

        public bool Active { get; set; }

        public int projectID { get; set; }

        public int Amount { get; set; }

        public ItemDiscountTypeViewModel Discount { get; set; }

        [Timestamp]
        public byte[] RowVision { get; set; }
    }
}
