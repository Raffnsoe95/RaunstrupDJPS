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
            Specialties = new List<Specialty>();
            Projects = new List<Project>();
        }
        public int Id { get; set; }

        public string Name { get; set; }

        public string Phone { get; set; }

        public bool Active { get; set; }

        [Timestamp]
        public byte[] RowVersion { get; set; }

        public int? TypeId { get; set; }
        public EmployeeType Type { get; set; }

        public List<Specialty> Specialties { get; set; }
        public List<Project> Projects { get; set; }

        public int? ManagerID { get; set; }

        public Employee Manager { get; set; }

        public int? DepartmentId { get; set; }
        public Department Department { get; set; }
    }
}
