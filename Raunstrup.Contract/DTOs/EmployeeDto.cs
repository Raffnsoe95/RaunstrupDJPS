using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

namespace Raunstrup.Contract.DTOs
{
    public class EmployeeDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public bool Active { get; set; }
        [Timestamp]
        public byte[] RowVersion { get; set; }
        public TypeDto Type { get; set; }
        public List<SpecialtyDto> Specialties { get; set; }
        public int? ManagerID { get; set; }
        public EmployeeDto Manager { get; set; }
    }
}
