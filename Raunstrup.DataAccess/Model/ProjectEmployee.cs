using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Raunstrup.DataAccess.Model
{
    public class ProjectEmployee
    {
        public int id { get; set; }
        public string EmployeeName { get; set; }
        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }
        public int ProjectId { get; set; }


    }
}
