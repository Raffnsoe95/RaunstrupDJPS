using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Mail;
using MailKit;
using MailKit.Net.Smtp;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MimeKit;
using Raunstrup.Contract.Services;
using Raunstrup.UI.Models;
using SmtpClient = MailKit.Net.Smtp.SmtpClient;
using Raunstrup.Contakt.Service.Interface;
using Raunstrup.Contract.DTOs;

namespace Raunstrup.UI.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IEmployeeservice _employeeService;
        //private readonly IContactService _contact;


        public HomeController(ILogger<HomeController> logger, IEmployeeservice employeeservice, IContactService contact)
        {
            _logger = logger;
            _employeeService = employeeservice;
            //_contact = contact;

        }

        public IActionResult Index()
        {
            ////Udkommenteret fordi det fucker op hvis man er logget ind som admin -Peder
            //if (User.Identity.IsAuthenticated)
            //{
            //    string bruger = User.Identity.Name;
            //    int id = Convert.ToInt32(bruger.Substring(0, 1));

            //    //EmployeeViewModel employeeViewModel = EmployeeMapper.Map(_employeeService.GetEmployeesAsync(id));
            //    var employeeDto = await _employeeService.GetEmployeesAsync(id).ConfigureAwait(false);

            //    return View(EmployeeMapper.Map(employeeDto));

            //}

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult CreateEmail(ContactViewModel contactViewModel)
        {
            var message = new MimeMessage();

            message.From.Add(new MailboxAddress("From", "raunstrupdjps@gmail.com"));
            message.To.Add(new MailboxAddress("To", "RaikoPrivate@hotmail.com"));
            message.Subject = contactViewModel.Subject;
            message.Body = new TextPart("text")
            {
                Text =
                "Navn " + contactViewModel.Name +
                "Tlf: " + contactViewModel.Phone +
                "Adresse: " + contactViewModel.Adress +
                "Email: " + contactViewModel.Email +
                contactViewModel.Message
            };

            using (var client = new SmtpClient())
            {
                client.Connect("smtp.Gmail.com", 587, false);
                client.Authenticate("raunstrupdjps@gmail.com", "RaunstrupDJPS123!");
                client.Send(message);

                client.Disconnect(true);
            }
            return RedirectToAction("Index");
        }

        //public async Task< IActionResult> CreateEmail(ContactDto contact)
        //{
        //    await _contact.SendEmail(contact).ConfigureAwait(false);
        //    return RedirectToAction("Index");
        //}

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
