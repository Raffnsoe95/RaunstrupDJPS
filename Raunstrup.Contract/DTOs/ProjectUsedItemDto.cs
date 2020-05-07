using Raunstrup.DataAccess.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Raunstrup.Contract.DTOs
{
    public class ProjectUsedItemDto
    {
        public int Id { get; set; }

        public int Amount { get; set; }

        public decimal Price { get; set; }

        public bool IsUsed { get; set; }

        public ItemDto Item { get; set; }

        public int ItemID { get; set; }

        public int ProjectId { get; set; }
    }
}
