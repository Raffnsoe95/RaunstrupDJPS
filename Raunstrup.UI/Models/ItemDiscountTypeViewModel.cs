using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Raunstrup.UI.Models
{
    public class ItemDiscountTypeViewModel
    {
        public int DiscountId {get;set;}
        public int DiscountPercentage { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int Amount { get;set; }
        public int ItemId { get; set; }

        [Timestamp]
        public byte[] RowVersion { get; set; }
    }
}
