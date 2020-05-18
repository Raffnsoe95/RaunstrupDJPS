using System;
using System.Collections.Generic;
using System.Text;

namespace Raunstrup.DataAccess.Model
{
    public class ItemDiscountType
    {
        public int Id { get; set; }

        public int DiscountPercentage { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public int Amount { get; set; }

        public int ItemId { get; set; }
    }
}
