using System;
using System.Collections.Generic;
using System.Text;

namespace Raunstrup.Contract.DTOs
{
    public class CustomerDiscountTypeDto
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public decimal DiscountPercent { get; set; }

        public bool active { get; set; }

        public int CustomerId { get; set; }

        public byte[] Rowversion { get; set; }
    }
}
