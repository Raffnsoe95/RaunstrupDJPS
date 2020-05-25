using Raunstrup.Contract.DTOs;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace Raunstrup.Contakt.Service.Interface
{
    public interface IContactService
    {
         //void SendEmail(ContactDto contact);

        void SendEmail(ContactDto contact);
        void SendOffer(string offer, string toAddress = "RaikoPrivate@hotmail.com");
    }
}
