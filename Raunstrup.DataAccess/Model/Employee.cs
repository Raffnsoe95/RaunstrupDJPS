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
        }
        public int Id { get; set; }

        public string Name { get; set; }

        public string Phone { get; set; }

        public bool Active { get; set; }

        [Timestamp]
        public byte[] RowVersion { get; set; }

        public EmployeeType Type { get; set; }

        public List<Specialty> Specialties { get; set; }

        public int? ManagerID { get; set; }

        public Employee Manager { get; set; }
    }
}
