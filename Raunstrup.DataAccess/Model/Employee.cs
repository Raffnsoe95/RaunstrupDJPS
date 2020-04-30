using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Raunstrup.DataAccess.Model
{
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Tlfnr { get; set; }
        public bool Active { get; set; }

        public List<WorkingHours> WorkingHours { get; set; }

        [Timestamp]
        public byte[] RowVersion { get; set; }
    }
}
