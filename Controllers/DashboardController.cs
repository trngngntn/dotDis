using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Models;
using Microsoft.AspNetCore.Http;
using System.Data;

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
                CollectData();
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
                this.HttpContext.Items.Add("error", true);
                return View("Login");
            }
            else if (admin.Login(passwd))
            {
                this.HttpContext.Session.SetInt32("active-admin", admin.Id);
                Console.WriteLine("[LOG] Admin `{0}` logged in.", username);
                return Redirect("/Dashboard");
            }
            else
            {
                return View("Login");
            }
        }

        [HttpGet]
        public IActionResult Table(string table)
        {
            string sql = "select * from " + table;
            DataTable dat = DAL.Database.GetData(sql);
            List<string> header = GetTableHeader(table);
            List<DataRow> list = new List<DataRow>();

            foreach (DataRow row in dat.Rows)
            {
                list.Add(row);
            }
            CollectData();
            ViewData["TableHeader"] = header;
            ViewData["TableData"] = list;
            return View("Temp");

        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        private void CollectData()
        {
            ViewData["Users"] = Models.User.CountAllUsers();
            ViewData["Rooms"] = Models.Room.CountAllRooms();
            ViewData["Messages"] = Models.Message.CountAllMessage();
            ViewData["DatabaseTables"] = DAL.Database.GetTables();
        }

        private List<string> GetTableHeader(string table)
        {
            List<string> header = new List<string>();
            switch (table)
            {
                case "Admin":
                    header.Add("ID");
                    header.Add("Username");
                    header.Add("Display Name");
                    header.Add("Salt");
                    header.Add("Password");
                    break;
                case "Channel":
                    header.Add("ID");
                    header.Add("Room ID");
                    header.Add("Name");
                    header.Add("Type");
                    break;
                case "Channel_Mesg":
                    header.Add("ID");
                    header.Add("Send ID");
                    header.Add("Channel ID");
                    header.Add("Created");
                    header.Add("Detail");
                    break;
                case "Friend":
                    header.Add("User ID 1");
                    header.Add("User ID 2");
                    header.Add("Status");
                    break;
                case "Permission":
                    header.Add("Role ID");
                    header.Add("Channel ID");
                    header.Add("Type");
                    break;
                case "Private_Mesg":
                    header.Add("ID");
                    header.Add("Send ID");
                    header.Add("Receiver ID");
                    header.Add("Created");
                    header.Add("Detail");
                    break;
                case "Role":
                    header.Add("ID");
                    header.Add("Room ID");
                    header.Add("Name");
                    break;
                case "Room":
                    header.Add("ID");
                    header.Add("Name");
                    header.Add("Owner ID");
                    break;
                case "Room_User":
                    header.Add("Room ID");
                    header.Add("User ID");
                    header.Add("Nickname");
                    break;
                case "Session":
                    header.Add("ID");
                    header.Add("User ID");
                    break;
                case "Test":
                    header.Add("ID");
                    header.Add("Name");
                    break;
                case "User":
                    header.Add("ID");
                    header.Add("Username");
                    header.Add("Fullname");
                    header.Add("Email");
                    header.Add("Salt");
                    header.Add("Password");
                    break;
                case "User_Role":
                    header.Add("User ID");
                    header.Add("Role ID");
                    break;
            }

            return header;
        }
    }
}