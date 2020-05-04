using System;
using System.Collections.Generic;
using System.Text;

namespace Raunstrup.Contract.DTOs
{
    public class ProjectDrivingDto
    {
        public int Id { get; set; }
        public int Amount { get; set; }
        public int EmployeeId { get; set; }
        public EmployeeDto Employee { get; set; }
        public decimal UnitPrice { get; set; }
        public int ProjectId { get; set; }
    }
}
