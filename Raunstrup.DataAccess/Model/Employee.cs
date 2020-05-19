using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Raunstrup.DataAccess.Model
{
    public class Employee
    {
        public Employee()
        {
            Specialty = new Specialty();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public string Phone { get; set; }

        public bool Active { get; set; }


        public int? TypeID { get; set; }

        [ForeignKey("TypeID")]
        public EmployeeType Type { get; set; }

        public int? SpecialtyID { get; set; }


        [ForeignKey("SpecialtyID")]
        public Specialty Specialty { get; set; }

        
        public int? ManagerID { get; set; }

       [ForeignKey("ManagerID")]
        public Employee Manager { get; set; }

       

         public int? DepartmentID { get; set; }

        [ForeignKey("DepartmentID")]
        public Department Department { get; set; }

        [Timestamp]
        public byte[] RowVersion { get; set; }
    }
}
