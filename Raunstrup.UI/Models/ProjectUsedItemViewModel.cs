using Raunstrup.Contract.DTOs;
using Raunstrup.DataAccess.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Raunstrup.UI.Models
{
    public class ProjectUsedItemViewModel
    {
        public int Id { get; set; }

        public int Amount { get; set; }

        public decimal Price { get; set; }

        public ItemViewModel Item { get; set; }

        public int ItemID { get; set; }

        public int ProjectId { get; set; }
    }
}
