using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Raunstrup.DataAccess.Model
{
    public class ProjectEmployee
    {
        public int Id { get; set; }
       
        public int EmployeeId { get; set; }

        public int EstWorkingHours { get; set; }

        public int ProjectId { get; set; }

        public Employee Employee { get; set; }
    }
}
