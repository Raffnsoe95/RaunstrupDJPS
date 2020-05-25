using MimeKit;
using System;
using MailKit.Net.Smtp;
using Raunstrup.Contract.DTOs;
using System.Threading.Tasks;
using Raunstrup.Contakt.Service.Interface;
using System.Linq;
using System.IO;

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

            using (var client = new SmtpClient())
            {
                client.Connect("smtp.Gmail.com", 587, false);
                client.Authenticate("raunstrupdjps@gmail.com", "RaunstrupDJPS123!");
                client.Send(message);

                client.Disconnect(true);
            }
        }

        public void SendOffer(string offer, string toAddress = "RaikoPrivate@hotmail.com")
        {
            var message = new MimeMessage();

            message.From.Add(new MailboxAddress("From", "raunstrupdjps@gmail.com"));
            message.To.Add(new MailboxAddress("To", toAddress));
            message.Subject = "tilbud";

            var builder = new BodyBuilder();

            // Set the plain-text version of the message text
            builder.TextBody = @"Tilbud vedhæftet";

            // We may also want to attach a calendar event for Monica's party...
            builder.Attachments.Add(offer);

            // Now we just need to set the message body and we're done
            message.Body = builder.ToMessageBody();

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
