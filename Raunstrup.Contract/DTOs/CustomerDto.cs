﻿using System;

namespace Raunstrup.Contract
{
    public class CustomerDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Phone { get; set; }

        public string Address { get; set; }

        public string Email { get; set; }

        public bool Active { get; set; }

        public byte[] Rowversion { get; set; }
    }
}
