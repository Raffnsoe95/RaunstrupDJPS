using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Raunstrup.UI.Models
{
    public class ContactViewModel
    {
        [Required(ErrorMessage = "Skal udfyldes")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Skal udfyldes")]
        [RegularExpression(@"^[0-9|+| |(|)]+$"), StringLength(30)]
        public string Phone { get; set; }

        [Required(ErrorMessage = "Skal udfyldes")]
        [EmailAddress(ErrorMessage = "Ikke gyldig email-adresse")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Skal udfyldes")]
        public string Subject { get; set; }

        [Required(ErrorMessage = "Skal udfyldes")]
        public string Message { get; set; }
    }
}
