using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Models;
using Microsoft.AspNetCore.Http;
using System.Net;
using System.Net.WebSockets;

namespace Controllers
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
            int? uid = this.HttpContext.Session.GetBindedUid();
            if (uid == null)
            {
                return Redirect("/Login");
            }
            else
            {
                ViewData["uid"] = uid;
                ViewData["Friend"] = Models.User.ListFriend((int)uid);
                return View();
            }

        }

        public IActionResult Logout()
        {
            int uid = (int)this.HttpContext.Session.GetBindedUid();
            this.HttpContext.Session.KillNow();
            return Redirect("/Login");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        
    }
}
