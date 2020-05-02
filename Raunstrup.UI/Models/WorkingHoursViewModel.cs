using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Raunstrup.UI.Models
{
    public class WorkingHoursViewModel
    {
        public int Id { get; set; }
        public int Amount { get; set; }
        public int EmployeeId { get; set; }

        public decimal HourlyPrice { get; set; }

        public int ProjectId { get; set; }

        public EmployeeViewModel Employee { get; set; }
    }
}
