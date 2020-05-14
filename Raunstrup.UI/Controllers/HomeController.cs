using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Raunstrup.Contract.Services;
using Raunstrup.UI.Models;


namespace Raunstrup.UI.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IEmployeeservice _employeeService;


        public HomeController(ILogger<HomeController> logger, IEmployeeservice employeeservice)
        {
            _logger = logger;
            _employeeService = employeeservice;
        }

        public async Task<IActionResult> Index()
        {
            //Udkommenteret fordi det fucker op hvis man er logget ind som admin -Peder
            if (User.Identity.IsAuthenticated)
            {
                string bruger = User.Identity.Name;
                int id = Convert.ToInt32(bruger.Substring(0, 1));

                //EmployeeViewModel employeeViewModel = EmployeeMapper.Map(_employeeService.GetEmployeesAsync(id));
                var employeeDto = await _employeeService.GetEmployeesAsync(id).ConfigureAwait(false);

                return View(EmployeeMapper.Map(employeeDto));

            }

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
