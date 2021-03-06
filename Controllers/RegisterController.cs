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
        public IActionResult Submit(string userid, string passwd){
            Console.WriteLine(userid + " " + passwd);
            this.HttpContext.Items.Add("ID", "this from login");
            //return RedirectToAction("Complete", new {id = 123});
            //return Json(customer);
            //return View(customer);
            return Redirect("/Chat");
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
