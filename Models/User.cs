using System;
using System.Collections.Generic;
using Utils;
using DAL;
using System.Text.Json.Serialization;

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

        [JsonPropertyName("id")]
        public int ID
        {
            get => id;
        }
        [JsonPropertyName("name")]
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

        public static object ListRoom(int uid)
        {
            return UserDAO.ListRoom(uid);
        }


        public static int CountAllUsers()
        {
            return UserDAO.CountAllUsers();
        }
    }
}