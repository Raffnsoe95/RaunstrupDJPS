using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Raunstrup.DataAccess.Model
{
    public class ProjectUsedItem
    {
        public int Id { get; set; }

        public int Amount { get; set; }

        public decimal Price { get; set; }

        public int ProjectId { get; set; }

        public int ItemID { get; set; }

        [ForeignKey("ItemID")]
        public Item Item { get; set; }
    }
}
