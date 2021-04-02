using System;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Models;
using Microsoft.AspNetCore.Http;

namespace Controllers
{
    public class RegisterController : Controller
    {
        private readonly ILogger<HomeController> _logger;   
        public RegisterController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Submit(string name, string email, string username, string passwd)
        {
            if(Models.User.GetUserByUsername(username) == null)
            {
                Models.User.CreateUser(name, email, username, passwd);
                Console.WriteLine("[LOG] Create new user `{0}`", username);
                return View("Success");
            }
            else {
                return View("Index");
            }
        }
        public IActionResult Success(string name)
        {
            ViewData["Name"] = name;
            return View();
        } 
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
