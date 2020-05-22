using System;
using System.Collections.Generic;
using System.Text;

namespace Raunstrup.Contract.DTOs
{
    public class ProjectEmployeeDto
    {
        public int Id { get; set; }
        //public EmployeeID {get;set;}
        public string EmployeeName { get; set; }
        public int EstWorkingHours { get; set; }
        public int ProjectId { get; set; }
        
        public EmployeeDto Employee { get; set; }

        public int? EmployeeID { get; set; } 

        //public ProjectDto Project { get; set; }
        


    }
}
