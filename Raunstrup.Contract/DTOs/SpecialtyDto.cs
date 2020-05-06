using System;
using System.Collections.Generic;
using System.Text;

namespace Raunstrup.Contract.DTOs
{
    public class SpecialtyDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public Decimal Bonus { get; set; }
        public int EmployeeId { get; set; }
    }
}
