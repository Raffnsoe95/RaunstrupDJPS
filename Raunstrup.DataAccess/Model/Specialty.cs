using System;
using System.Collections.Generic;
using System.Text;

namespace Raunstrup.DataAccess.Model
{
    public class Specialty
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public Decimal Bonus { get; set; }
        public int EmployeeId { get; set; }
    }
}
