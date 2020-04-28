using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Raunstrup.DataAccess.Model
{
    public class Item
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }

        public bool Active { get; set; }

        [Timestamp]
        public byte[] RowVision { get; set; }
    }
}
