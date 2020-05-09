using Raunstrup.Contract.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Raunstrup.UI.Models
{
    public class CustomerDiscountTypeViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public decimal DiscountPercent { get; set; }

        public bool Active { get; set; }
        public int CustomerId { get; set; }
    }
}
