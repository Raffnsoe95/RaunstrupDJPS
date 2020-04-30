using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.RegularExpressions;

namespace Raunstrup.UI.Models
{
    public class CustomerViewModel
    {
        public int Id { get; set; }

       [RegularExpression(@"^[a-zA-Z|æ|Æ|ø|Ø|å|Å| ]{2,50}$"), StringLength(50)]
        public string Name { get; set; }

       [RegularExpression(@"^[0-9|+| |(|)]+$"), StringLength(30)]
        public string Phone { get; set; }

        [RegularExpression(@"^[a-zA-Z0-9|æ|Æ|ø|Ø|å|Å| |.|,]{2,50}$")]
        public string Address { get; set; }


        [RegularExpression(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$")]
        public string Email { get; set; }

        public bool Active { get; set; }

        public byte[] Rowversion {get; set;}
    }
}
