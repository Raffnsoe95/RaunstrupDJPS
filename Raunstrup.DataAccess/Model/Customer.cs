using Raunstrup.DataAccess.Model;
using System;
using System.ComponentModel.DataAnnotations;

namespace Raunstrup.DataAccess
{
    public class Customer
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Phone { get; set; }

        public string Address { get; set; }

        public string Email { get; set; }

        public bool Active { get; set; }

        public CustomerDiscountType CustomerDiscountType { get; set; }

        [Timestamp]
        public byte[] Rowversion { get; set; }

    }
}
