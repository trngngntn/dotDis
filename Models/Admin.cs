using System;
using System.Collections.Generic;
using dotdis.Util;
using DAL;

namespace Models
{
    public class Admin
    {
        private static HashSet<Admin> activeAdmin;
        private int id;
        private string username;
        private string displayName;
        private string salt;

        public Admin(int id, string username, string displayName, string salt)
        {
            this.id = id;
            this.username = username;
            this.displayName = displayName;
            this.salt = salt;
        }

        public Admin(int id, string displayName)
        {
            this.id = id;
            this.displayName = displayName;
        }

        public int Id { get => id; }
        public string Username { get => username; set => username = value; }
        public string DisplayName { get => displayName; set => displayName = value; }
        public string Salt { get => salt; set => salt = value; }

        public bool Login(string passwd)
        {
            salt = AdminDAO.GetSalt(id);
            string pwd = Cryptor.GenerateHash(passwd, salt);
            Console.WriteLine("[AUTH] " + salt + " " + pwd);
            return AdminDAO.ComparePwd(id, pwd) == 1;
        }

        public void Logout()
        {

        }

        public static Admin GetAdminByUsername(string username)
        {
            return AdminDAO.GetAdminByUsername(username);
        }

    }
}