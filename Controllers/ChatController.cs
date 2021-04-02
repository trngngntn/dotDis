using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Models;
using Microsoft.AspNetCore.Http;
using DAL;
using System.Text.Json;
using Utils;

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
                ViewData["active-user"] = UserDAO.GetUserByID((int)uid);
                ViewData["list-friend"] = Models.User.ListFriend((int)uid);
                ViewData["list-room"] = Models.User.ListRoom((int)uid);
                return View();
            }
        }

        public IActionResult RoomSetting(int roomId)
        {
            int? uid = this.HttpContext.Session.GetBindedUid();
            if (uid == null)
            {
                return Redirect("/Login");
            }
            else
            {
                int perm = RoomDAO.GetPermission(roomId, (int)uid);
                if(perm >= RoomDAO.PERM_MOD)
                {
                    RoomDAO.GetMembers();
                }
                //ViewData["active-user"] = UserDAO.GetUserByID((int)uid);
                //ViewData["list-friend"] = Models.User.ListFriend((int)uid);
                return View();
            }
        }

        public String AddRoom(string name, int uid)
        {
            ConsoleLogger.Log("Add room {0}:{1}", name, uid);
                return RoomDAO.Create(name, uid).ToString();
        }

        public String SearchUser(string str)
        {
            if (str == null || str.Equals("")) return "";
            //ConsoleLogger.Log("Search for '{0}'", str);
            List<User> found = UserDAO.Find(str);
            return JsonSerializer.Serialize<List<User>>(found);
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
