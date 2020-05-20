using Raunstrup.Contract.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Raunstrup.UI.Models
{
    public class ContactMapper
    {
        public static ContactViewModel Map(ContactDto dto)
        {
            if (dto == null)
                return null;
            return new ContactViewModel
            {
                Name = dto.Name,
                Phone = dto.Phone,
                Email = dto.Email,
                Adress = dto.Adress,
                Subject = dto.Subject,
                Message = dto.Message
            };
        }

        public static IEnumerable<ContactViewModel> Map(IEnumerable<ContactDto> dtos)
        {
            return dtos.Select(x => Map(x)).AsEnumerable();
        }

        public static ContactDto Map(ContactViewModel view)
        {
            if (view == null)
                return null;
            return new ContactDto
            {
                Name = view.Name,
                Phone = view.Phone,
                Email = view.Email,
                Adress = view.Adress,
                Subject = view.Subject,
                Message = view.Message
            };
        }
    }
}
