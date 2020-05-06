using System;
using System.Collections.Generic;
using System.Text;

namespace Raunstrup.DataAccess.Model
{
    public class EmployeeType
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public Decimal HourlyPrice { get; set; }
        public int EmployeeId { get; set; }
    }
}
