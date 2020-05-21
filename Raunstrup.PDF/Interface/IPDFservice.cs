using Raunstrup.Contract.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Raunstrup.PDF.Interface
{ 
    
        public interface IPDFService
        {
            //void SendEmail(ContactDto contact);

            void CreatePDF(PDFDto pdf);
        }
}
