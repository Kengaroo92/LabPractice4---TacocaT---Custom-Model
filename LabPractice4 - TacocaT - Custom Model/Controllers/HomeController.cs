using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using LabPractice4___TacocaT___Custom_Model.Models;
using System.Security.Cryptography.X509Certificates;

namespace LabPractice4___TacocaT___Custom_Model.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult TacocaT()
        {
            return View();
        }

        [HttpPost]
        public IActionResult TacocaT(string userInput)
        {
            var tacocat = new TacocaTModel
            {
                UserInput = userInput,
                ReverseWord = string.Join("", userInput.Reverse().ToArray()),
                Result = ""
            };

            if (tacocat.UserInput == tacocat.ReverseWord)
            {
                tacocat.Result = " is a Result!";
            }
            else
            {
                tacocat.Result = " is not a Result!";
            }

            return RedirectToAction("Result", tacocat);

        }

        public IActionResult Result()
        {

            var model = new TacocaTModel();

            return View(model);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
