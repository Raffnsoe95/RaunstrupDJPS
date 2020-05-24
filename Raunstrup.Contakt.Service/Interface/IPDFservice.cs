using Raunstrup.Contract.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Raunstrup.Contakt.Service.Interface
{

    public interface IPDFService
    {
        //void SendEmail(ContactDto contact);

        void CreatePDF(ProjectDetailsDto pdf);
    }
}
