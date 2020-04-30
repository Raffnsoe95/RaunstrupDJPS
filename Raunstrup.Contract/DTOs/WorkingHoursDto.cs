using System;
using System.Collections.Generic;
using System.Text;

namespace Raunstrup.Contract.DTOs
{
   public class WorkingHoursDto
    {
        public int Id { get; set; }
        public int Amount { get; set; }
        public int EmployeeId { get; set; }

        public int ProjectId { get; set; }
        public ProjectDto Project { get; set; }
        public EmployeeDto Employee { get; set; }
    }
}
