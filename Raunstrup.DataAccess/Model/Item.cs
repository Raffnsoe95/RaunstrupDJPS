using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Raunstrup.DataAccess.Model
{
    public class Item
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }

        public bool Active { get; set; }

       
        
        public int? DiscountID { get; set; }

        [ForeignKey("DiscountID")]
        public ItemDiscountType Discount { get; set; }

        [Timestamp]
        public byte[] RowVersion { get; set; }
    }
}
