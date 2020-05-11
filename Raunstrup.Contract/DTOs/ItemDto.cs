using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace Raunstrup.Contract.DTOs
{
    public class ItemDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }

        public bool Active { get; set; }
        //discount - Sim
        public ItemDiscountTypeDto Discounts { get; set; }

        [Timestamp]
        public byte[] RowVision { get; set; }
    }
}
