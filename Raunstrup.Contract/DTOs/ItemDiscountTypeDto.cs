using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

namespace Raunstrup.Contract.DTOs
{
    public class ItemDiscountTypeDto
    {
        public int DiscountId { get; set; }
        public int DiscountPercentage { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int Amount { get; set; }
        public int ItemId { get; set; }

        [Timestamp]
        public byte[] RowVersion { get; set; }
    }
}
