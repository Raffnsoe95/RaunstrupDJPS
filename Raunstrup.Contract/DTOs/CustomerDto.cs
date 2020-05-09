using System;
using System.ComponentModel.DataAnnotations;

namespace Raunstrup.Contract.DTOs
{
    public class CustomerDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Phone { get; set; }

        public string Address { get; set; }

        public string Email { get; set; }

        public CustomerDiscountTypeDto CustomerDiscountType { get; set; }
        public bool Active { get; set; }
        [Timestamp]
        public byte[] Rowversion { get; set; }
    }
}
