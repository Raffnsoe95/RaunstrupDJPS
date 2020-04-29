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

       
        public string Name { get; set; }

        //[RegularExpression(@"^[0-9]()+*$"), Required, StringLength(30)]//jeg er ikke sikker på om de tegn der står med pink er rigtige
        public string Phone { get; set; }

       // [RegularExpression(@"^[0-9][A-Z]+[a-zA-Z""'\s-]*$"), Required, StringLength(30)]
        public string Address { get; set; }


        //der skal være en ordenlig emailtjekker her
        public string Email { get; set; }

        public bool Active { get; set; }

        public byte[] Rowversion {get; set;}
    }
}
