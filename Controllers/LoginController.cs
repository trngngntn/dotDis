using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using dotdis.Models;
using Microsoft.AspNetCore.Http;

namespace dotdis.Controllers
{
    public class LoginController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        public LoginController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            if(this.HttpContext.Items["error"] == null){
                ViewData["Error"] = "";
            }
            return View();
            
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Authorize(string username, string passwd){
            Console.WriteLine(username + " " + passwd);
            this.HttpContext.Items.Add("ID", "this from login");
            User user = dotdis.Models.User.GetUserByUsername(username);
            if(user == null) // not found
            {
                Console.WriteLine("[LOG] User `{0}` not found!", username);
                this.HttpContext.Items.Add("error",true);
                return View("Index");
            }
            else if(user.Login(passwd))
            {
                Console.WriteLine("[LOG] User `{0}` logged in.", username);
                return Redirect("/Chat");
            }
            else return View("Index");
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
