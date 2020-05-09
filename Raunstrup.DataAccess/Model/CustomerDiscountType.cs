using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Raunstrup.DataAccess.Model
{
    public class CustomerDiscountType
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public decimal DiscountPercent { get; set; }

        public bool Active { get; set; }

        public int CustomerID { get; set; }

        [Timestamp]
        public byte[] Rowversion { get; set; }
    }
}
