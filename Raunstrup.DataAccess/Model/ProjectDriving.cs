using System;
using System.Collections.Generic;
using System.Text;

namespace Raunstrup.DataAccess.Model
{
    public class ProjectDriving
    {
        public int Id { get; set; }
        public int Amount { get; set; }
        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }
        public decimal UnitPrice { get; set; }
        public int ProjectId { get; set; }
    }
}
