using System;
using System.Collections.Generic;
using System.Text;

namespace Raunstrup.Contract.DTOs
{
    public class ProjectEmployeeDto
    {
        public int EmployeeId { get; set; }

        public string EmployeeName { get; set; }
        public int ProjectId { get; set; }

        public EmployeeDto Employee { get; set; }

        public ProjectDto Project { get; set; }



    }
}
