using Raunstrup.Contract.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Raunstrup.Contakt.Service.Interface
{
    public interface IContactService
    {
         //void SendEmail(ContactDto contact);

        void SendEmail(ContactDto contact);
    }
}
