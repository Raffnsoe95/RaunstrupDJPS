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
        private readonly IContactService _contact;


        public HomeController(ILogger<HomeController> logger, IEmployeeservice employeeservice, IContactService contact)
        {
            _logger = logger;
            _employeeService = employeeservice;
            _contact = contact;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Contact()
        {
            return View();
        }

        public IActionResult CreateEmail(ContactViewModel contact)
        {
            try
            {
                _contact.SendEmail(ContactMapper.Map(contact));
                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                ErrorViewModel model = new ErrorViewModel { RequestId = "Kunne ikke Sende Email" };
                return View("Error", model);
            }
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
