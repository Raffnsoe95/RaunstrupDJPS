using System;
using System.Collections.Generic;
using System.Text;

namespace Raunstrup.DataAccess.Model
{
    public class ProjectAssignedItem
    {
        public int Id { get; set; }

        public int Amount { get; set; }

        public decimal Price { get; set; }

        public int ProjectId { get; set; }

        public int ItemID { get; set; }

        public Item Item { get; set; }
    }
}
