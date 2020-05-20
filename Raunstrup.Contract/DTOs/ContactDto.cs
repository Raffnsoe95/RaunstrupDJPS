using System;
using System.Collections.Generic;
using System.Text;

namespace Raunstrup.Contract.DTOs
{
    public class ContactDto
    {        
        public string Name { get; set; }
        
        public string Phone { get; set; }
        
        public string Email { get; set; }

        public string Adress { get; set; }
        
        public string Subject { get; set; }

        public string Message { get; set; }
    }
}
