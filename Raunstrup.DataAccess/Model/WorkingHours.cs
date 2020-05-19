using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System.Text;

namespace Raunstrup.DataAccess.Model
{
    public class WorkingHours
    {
        public WorkingHours()
        {
            Employee = new Employee();
        }
        public int Id { get; set; }

        public int Amount { get; set; }
       
        public decimal HourlyPrice { get; set; }

        public int ProjectId { get; set; }

        public int EmployeeID { get; set; }

        [ForeignKey("EmployeeID")]
        public Employee Employee { get; set; }

    }
}
