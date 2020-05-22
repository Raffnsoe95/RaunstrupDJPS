using MimeKit;
using System;
using MailKit.Net.Smtp;
using Raunstrup.Contract.DTOs;
using System.Threading.Tasks;
using Raunstrup.Contakt.Service.Interface;
using System.Linq;

namespace Raunstrup.Contakt.Service
{
    public class ContactService : IContactService
    {

        public void SendEmail(ContactDto contact)
        {
            var message = new MimeMessage();

            message.From.Add(new MailboxAddress("From", contact.Email));
            message.To.Add(new MailboxAddress("To", "RaikoPrivate@hotmail.com"));
            message.Subject = contact.Subject;
            message.Body = new TextPart("text","html")
            {
                Text =
                "Navn: " + contact.Name + "<Br>" +
                "Tlf: " + contact.Phone + "<Br>" +
                "Adresse: " + contact.Adress + "<Br>" +
                "Email: " + contact.Email + "<Br>" +
                "<Br>" +
                contact.Message
            };

            //var body = message.BodyParts.OfType().FirstOrDefault(x => x.ContentType.Matches("text", "html"));


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
