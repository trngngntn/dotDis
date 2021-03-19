using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Models;
using Microsoft.AspNetCore.Http;

namespace Controllers
{
    public class DashboardController : Controller
    {
        private readonly ILogger<DashboardController> _logger;
        public DashboardController(ILogger<DashboardController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            if (this.HttpContext.Session.GetInt32("active-admin") != null)
            {
                return View("Index");
            }

            if (this.HttpContext.Items["error"] == null)
            {
                ViewData["Error"] = "";
            }

            return View("Login");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Authorize(string username, string passwd)
        {
            this.HttpContext.Items.Add("ID", "this from login");
            Admin admin = Models.Admin.GetAdminByUsername(username);
            if (admin == null)
            {
                Console.WriteLine("[LOG] Admin `{0}` not found!", username);
                this.HttpContext.Items.Add("error",true);
                return View("Login");
            } else if (admin.Login(passwd)) {
                this.HttpContext.Session.SetInt32("active-admin", admin.Id);
                Console.WriteLine("[LOG] Admin `{0}` logged in.", username);
                CollectData();
                return View("Index");
            } else {
                return View("Login");
            }
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        private void CollectData() {
            ViewData["Users"] = Models.User.CountAllUsers();
            ViewData["Rooms"] = Models.Room.CountAllRooms();
            ViewData["Messages"] = Models.Message.CountAllMessage();
        }
    }
}