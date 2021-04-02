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
using MySql.Data.MySqlClient;
using System.Text.Json;

namespace Controllers
{
    public class DashboardController : Controller
    {
        private readonly ILogger<DashboardController> _logger;
        private List<string> tableHasId = new List<string>() {
                "Admin",
                "Channel",
                "Channel_Mesg",
                "Private_Mesg",
                "Role",
                "Room",
                "Session",
                "User"
            };

        private List<string> tableNoId = new List<string>() {
                "Friend",
                "Permission",
                "Room_User",
                "User_Role"
            };
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
        public IActionResult Table(string table, int? pageIndex)
        {
            if (this.HttpContext.Session.Get("active-admin") == null)
            {
                return Redirect("/Dashboard");
            }
            else
            {
                string tbl = ValidateTableName(table);
                string sql = "SELECT * FROM `" + tbl + "` ORDER BY 1 LIMIT @pageIndex, @pageSize";
                if (pageIndex == null)
                {
                    pageIndex = 1;
                }
                int pageSize = 20;

                MySqlParameter[] paras = new MySqlParameter[] {
                new MySqlParameter("@pageIndex", MySqlDbType.Int32),
                new MySqlParameter("@pageSize", MySqlDbType.Int32)
                };

                paras[0].Value = (pageIndex - 1) * pageSize;
                paras[1].Value = pageSize;

                DataTable dat = DAL.Database.GetData(sql, paras);
                List<string> header = GetTableHeader(table);
                List<DataRow> list = new List<DataRow>();

                foreach (DataRow row in dat.Rows)
                {
                    list.Add(row);
                }

                int total = CountRows(table);
                int maxPage = total / pageSize;
                if (total % pageSize > 0)
                {
                    maxPage++;
                }

                ViewData["TableName"] = table;
                ViewData["TableHeader"] = header;
                ViewData["TableData"] = list;
                ViewData["DatabaseTables"] = DAL.Database.GetTables();
                ViewData["maxPage"] = maxPage;
                ViewData["pageIndex"] = pageIndex;

                return View("Table");
            }
        }

        public IActionResult SQLStatement(string table)
        {
            if (this.HttpContext.Session.Get("active-admin") == null)
            {
                return Redirect("/Dashboard");
            }
            else
            {
                ViewData["DatabaseTables"] = DAL.Database.GetTables();
                return View("SQLStatement");
            }
        }

        [HttpGet]
        public IActionResult SQLExecute(string sql)
        {

            if (this.HttpContext.Session.Get("active-admin") == null)
            {
                return Redirect("/Dashboard");
            }
            else
            {
                string[] spl = sql.Split(' ');


                DataTable dat = DAL.Database.GetData(sql);
                //List<string> header = GetTableHeader(table);
                List<DataRow> list = new List<DataRow>();

                foreach (DataRow row in dat.Rows)
                {
                    list.Add(row);
                }

                ViewData["TableData"] = list;
                ViewData["ColumnCount"] = dat.Columns.Count;
                ViewData["DatabaseTables"] = DAL.Database.GetTables();

                return View("SQLStatement");
            }
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

        private string ValidateTableName(string table)
        {
            if (tableHasId.Contains(table) || tableNoId.Contains(table))
            {
                return table;
            }
            return "Admin";
        }

        private int CountRows(string table)
        {
            string sql = "SELECT COUNT(*) FROM " + ValidateTableName(table);
            DataTable dat = DAL.Database.GetData(sql);
            return Convert.ToInt32(dat.Rows[0][0].ToString());
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