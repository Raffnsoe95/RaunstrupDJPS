using MimeKit;
using System;
//using Raunstrup.UI.Models;
using MailKit.Net.Smtp;

namespace Raunstrup.Contakt.Service
{
    public class ContactService
    {
        //private readonly ContactViewModel _contactViewModel;

        //public ContractService() 
        //{




        //}

        //public void SendEmail(ContactViewModel contactViewModel)
        //{
        //    var message = new MimeMessage(ContactViewModel contactViewModel);

        //    message.From.Add(new MailboxAddress("From", contactViewModel.Email));
        //    message.To.Add(new MailboxAddress("To", "RaikoPrivate@hotmail.com"));
        //    message.Subject = contactViewModel.Subject;
        //    message.Body = new TextPart("text")
        //    {
        //        Text = contactViewModel.Name + contactViewModel.Message + contactViewModel.Email
        //    };

        //    using (var client = new SmtpClient())
        //    {
        //        client.Connect("smtp.Gmail.com", 587, false);
        //        client.Authenticate("raunstrupdjps@gmail.com", "RaunstrupDJPS123!");
        //        client.Send(message);

        //        client.Disconnect(true);
        //    }
        //}
    }
}
