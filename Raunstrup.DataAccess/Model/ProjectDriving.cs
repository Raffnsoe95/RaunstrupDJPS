using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Raunstrup.DataAccess.Model
{
    public class ProjectDriving
    {
        public int Id { get; set; }

        public int Amount { get; set; }

        public decimal UnitPrice { get; set; }

        public int ProjectId { get; set; }

        public int EmployeeID { get; set; }

        [ForeignKey("EmployeeID")]
        public Employee Employee { get; set; }
    }
}
