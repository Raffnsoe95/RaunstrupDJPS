using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.RegularExpressions;
using Newtonsoft.Json.Serialization;

namespace Raunstrup.UI.Models
{
    public class CustomerViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Skal udfyldes")]
       // [RegularExpression(@"^([\w{L}|æ|Æ|ø|Ø|å|Å| |.|,|-]*?)\s+([\w{L}|æ|Æ|ø|Ø|å|Å| |.|,|-]*)$"), StringLength(50)]
        public string Name { get; set; }

        [Required(ErrorMessage = "Skal udfyldes")]
        [RegularExpression(@"^[0-9|+| |(|)]+$"), StringLength(30)]
        
        public string Phone { get; set; }

        [Required(ErrorMessage = "Skal udfyldes")]
       // [RegularExpression(@"^[a-zA-Z0-9|æ|Æ|ø|Ø|å|Å| |.|,]{5,80}$")]
        public string Address { get; set; }

        [Required(ErrorMessage = "Skal udfyldes")]
        [EmailAddress(ErrorMessage ="Ikke gyldig email-adresse")]
        public string Email { get; set; }

        public bool Active { get; set; }

        public byte[] Rowversion {get; set;}
    }
}
