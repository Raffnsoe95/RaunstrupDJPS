using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Raunstrup.UI.Models
{
    public class EmployeeViewModel
    {
        public int Id { get; set; }
        [StringLength(60, MinimumLength = 3)]
        public string Name { get; set; }
        public string Tlfnr { get; set; }
        public decimal Salary { get; set; }
        public bool Active { get; set; }
        
        
    }
}
