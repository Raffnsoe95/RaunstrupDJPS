using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Raunstrup.UI.Models
{
    public class EstWorkingHoursEmployeeViewModel
    {
       
        public int Id { get; set; }


        public int ProjectId { get; set; }

        public int EstWorkingHours { get; set; }
       
        public int? EmployeeID { get; set; }

        public EmployeeViewModel Employee { get; set; }

       



    }
}
