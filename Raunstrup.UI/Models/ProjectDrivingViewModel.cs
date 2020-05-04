using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Raunstrup.UI.Models
{
    public class ProjectDrivingViewModel
    {
        public int Id { get; set; }
        public int Amount { get; set; }
        public int EmployeeId { get; set; }
        public EmployeeViewModel Employee { get; set; }
        public decimal UnitPrice { get; set; }
        public int ProjectId { get; set; }
    }
}
