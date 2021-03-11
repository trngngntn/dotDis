using System;
using System.Collections.Generic;
using dotdis.Util;
using DAL;

namespace Models
{
    public class User
    {
        private static HashSet<User> activeUser;
        private int id;
        private string username;
        private string name;
        private string email;
        private string salt;
        private int status;
        public User(int id, string name, string email, string salt)
        {
            this.id = id;
            this.name = name;
            this.email = email;
            this.salt = salt;
        }

        public User(int id, string name)
        {
            this.id = id;
            this.name = name;
        }
        public int ID
        {
            get => id;
        }
        public string Name
        {
            get => name;
            set => name = value;
        }
        public string Email
        {
            get => email;
        }
        public string Salt
        {
            get => salt;
        }
        public bool Login(string passwd)
        {
            salt = UserDAO.GetSalt(id);
            String pwd = Cryptor.GenerateHash(passwd, salt);
            Console.WriteLine("[AUTH] " + salt + " " + pwd);
            return UserDAO.ComparePwd(id, pwd) == 1;
        }
        public void Logout()
        {

        }
        public static User GetUserByUsername(string username)
        {
            return UserDAO.GetUserByUsername(username);
        }

        public static bool CreateUser(string name, string email, string username, string passwd)
        {
            return UserDAO.CreateNewUser(name, email, username, passwd) == 1;
        }

        public static List<int> ListFriendUid(int uid)
        {
            return UserDAO.ListFriendUid(uid);
        }

        public static List<User> ListFriend(int uid)
        {
            return UserDAO.ListFriend(uid);
        }
    }
}