using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Raunstrup.UI.Models
{
    public class EmployeeViewModel
    {
        public int Id { get; set; }
        [RegularExpression(@"[A-Z]+[a-zA-Z]"),]
        public string Name { get; set; }
        [RegularExpression(@"[0-9()+]"), StringLength(5)]
        public string Tlfnr { get; set; }
        [RegularExpression(@"[0-9].,"), StringLength(5)]
        public decimal Salary { get; set; }
        public bool Active { get; set; }
        
        
    }
}
