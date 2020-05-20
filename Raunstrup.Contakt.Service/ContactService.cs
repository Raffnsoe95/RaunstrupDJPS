using MimeKit;
using System;
//using Raunstrup.UI.Models;
using MailKit.Net.Smtp;
using Raunstrup.Contract.DTOs;
using System.Threading.Tasks;

namespace Raunstrup.Contakt.Service
{
    public class ContactService
    {

        private readonly ContactDto _contact;

        public ContactService(ContactDto contact) 
        {
            _contact = contact;
        
        }


        public void SendEmail(ContactDto contact)
        {
            var message = new MimeMessage(contact);

            message.From.Add(new MailboxAddress("From", contact.Email));
            message.To.Add(new MailboxAddress("To", "RaikoPrivate@hotmail.com"));
            message.Subject = contact.Subject;
            message.Body = new TextPart("text")
            {
                Text =
                "Navn " + contact.Name +
                "Tlf: " + contact.Phone +
                "Adresse: " + contact.Adress +
                "Email: " + contact.Email +
                contact.Message
            };

            using (var client = new SmtpClient())
            {
                client.Connect("smtp.Gmail.com", 587, false);
                client.Authenticate("raunstrupdjps@gmail.com", "RaunstrupDJPS123!");
                client.Send(message);

                client.Disconnect(true);
            }
        }
    }
}
