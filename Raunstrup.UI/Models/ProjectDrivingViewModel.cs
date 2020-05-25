using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Raunstrup.UI.Models
{
    public class ProjectDrivingViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Indtast venligst et antal enheder!")]
        [Range(0.01, 100000, ErrorMessage = "Angiv venligst et antal enheder!")]
        [RegularExpression(@"^[\d,.]+$", ErrorMessage = "Indtast venligst et nummer")]
        public int Amount { get; set; }
        public int EmployeeId { get; set; }
        public EmployeeViewModel Employee { get; set; }
        [Range(0.01, 100000, ErrorMessage = "Angiv venligst en korrekt enhedspris!")]
        [Required(ErrorMessage = "Indtast venligst en enhedspris!")]
        [DataType(DataType.Currency, ErrorMessage = "Indtast venligst en enhedspris")]
        [RegularExpression(@"^[\d,.]+$", ErrorMessage = "Indtast venligst et nummer")]
        public decimal UnitPrice { get; set; }
        public int ProjectId { get; set; }
    }
}
