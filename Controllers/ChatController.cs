using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Models;
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
            int? uid = this.HttpContext.Session.GetBindedUid();
            if (uid == null)
            {
                return Redirect("/Login");
            }
            else
            {
                ViewData["uid"] = uid;
                ViewData["friend"] = Models.User.ListFriend((int)uid);
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
