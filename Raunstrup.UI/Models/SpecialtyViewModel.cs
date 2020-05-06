using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Raunstrup.UI.Models
{
    public class SpecialtyViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public Decimal Bonus { get; set; }
        public int EmployeeId { get; set; }
    }
}
