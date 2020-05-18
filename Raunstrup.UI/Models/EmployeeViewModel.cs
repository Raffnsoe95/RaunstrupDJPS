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
            Projects = new List<ProjectViewModel>();
        }
        public int Id { get; set; }

        //[RegularExpression(@"[A-ZØ]+[a-zøA-ZØ]"),StringLength(200)]
        //[Required(ErrorMessage = "Skal udfyldes")]
        public string Name { get; set; }

        //[Required(ErrorMessage = "Skal udfyldes")]
        //[RegularExpression(@"[0-9()+]"), StringLength(9)]
        public string Phone { get; set; }

        public bool Active { get; set; }
        public int projectId { get; set; }
        [Timestamp]
        public byte[] RowVersion { get; set; }

        public TypeViewModel Type { get; set; }

        public List<SpecialtyViewModel> Specialties { get; set; }

        public int? ManagerID { get; set; }

        public EmployeeViewModel Manager { get; set; }

        public DepartmentViewModel Department { get; set; }

        public List<ProjectViewModel> Projects { get; set; }

        public ProjectEmployeeViewModel ProjectEmployees { get; set; }
    }
}
