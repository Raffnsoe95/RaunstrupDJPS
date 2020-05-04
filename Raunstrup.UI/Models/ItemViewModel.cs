﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Raunstrup.UI.Models
{
    public class ItemViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }

        public bool Active { get; set; }

        [Timestamp]
        public byte[] RowVision { get; set; }
    }
}