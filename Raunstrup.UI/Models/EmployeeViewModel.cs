using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Raunstrup.UI.Models
{
    public class EmployeeViewModel
    {
        public EmployeeViewModel()
        {
            Specialties = new List<SpecialtyViewModel>();
        }
        public int Id { get; set; }
        [RegularExpression(@"[A-ZØ]+[a-zøA-ZØ]"),StringLength(200)]
        public string Name { get; set; }
        [RegularExpression(@"[0-9()+]"), StringLength(9)]
        public string Phone { get; set; }
        public bool Active { get; set; }
        [Timestamp]
        public byte[] RowVersion { get; set; }
        public TypeViewModel Type { get; set; }
        public List<SpecialtyViewModel> Specialties { get; set; }
        public int? ManagerID { get; set; }
        public EmployeeViewModel Manager { get; set; }
    }
}
