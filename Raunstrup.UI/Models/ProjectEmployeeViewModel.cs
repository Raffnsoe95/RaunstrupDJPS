using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Raunstrup.Contract.DTOs;

namespace Raunstrup.UI.Models
{
    public class ProjectEmployeeViewModel
    {

        public int Id { get; set; }
        //public int EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        public int EmployeeId { get; set; }
        public int EstWorkingHours { get; set; }
        public EmployeeViewModel Employee { get; set; }
        public ProjectViewModel Project { get; set; }
        public int ProjectId { get; set; }
        
    }
}

