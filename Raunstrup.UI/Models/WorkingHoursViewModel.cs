using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Raunstrup.UI.Models
{
    public class WorkingHoursViewModel
    {
        public int WorkingHoursId { get; set; }
        public int Amount { get; set; }
        public int? EmployeeId { get; set; }

        public decimal HourlyPrice { get; set; }

        public int ProjectId { get; set; }

        public EmployeeViewModel Employee { get; set; }

        [Timestamp]
        public byte[] Rowversion { get; set; }
    }
}
