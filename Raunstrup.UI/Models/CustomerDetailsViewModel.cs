﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Raunstrup.UI.Models
{
    public class CustomerDetailsViewModel
    {

        public int Id { get; set; }

        [Required(ErrorMessage = "Skal udfyldes")]
        // [RegularExpression(@"^([\w{L}|æ|Æ|ø|Ø|å|Å| |.|,|-]*?)\s+([\w{L}|æ|Æ|ø|Ø|å|Å| |.|,|-]*)$"), StringLength(50)]
        public string Name { get; set; }

        [Required(ErrorMessage = "Skal udfyldes")]
        [RegularExpression(@"^[0-9\+ \(\)]+$", ErrorMessage = "Indtast venligst et korrekt telefonnummer"), StringLength(30)]
        public string Phone { get; set; }

        [Required(ErrorMessage = "Skal udfyldes")]
        // [RegularExpression(@"^[a-zA-Z0-9|æ|Æ|ø|Ø|å|Å| |.|,]{5,80}$")]
        public string Address { get; set; }

        [Required(ErrorMessage = "Skal udfyldes")]
        [EmailAddress(ErrorMessage = "Ikke gyldig email-adresse")]
        public string Email { get; set; }

        public bool Active { get; set; }

        public CustomerDiscountTypeViewModel CustomerDiscountType { get; set; }


        public int? CustomerDiscountTypeId { get; set; }

        public IEnumerable<ProjectViewModel> Projects { get; set; }

        public byte[] Rowversion { get; set; }
    }
}
