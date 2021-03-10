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
    public class ChatController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        public ChatController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            String activeUserId = HttpContext.Session.GetString("active-user");
            if(activeUserId == null){
                //Console.WriteLine(this.HttpContext.Items["ID"]);
                return Redirect("/Login");
            } else {
                ViewData["uid"] = activeUserId;
                return View();
            }
            
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
