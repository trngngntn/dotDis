using System;
using System.Collections.Generic;

namespace dotdis.Models
{
    public class User
    {
        private static HashSet<User> activeUser;
        private string id;
        private string name;
        private string email;
        private string password;
        private int status;
        public User(string id, string name, string email, string password)
        {
            this.id = id;
            this.name = name;
            this.email = email;
            this.password = password;
        }
        public string ID
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
        public string Password
        {
            get => password;
            set => password = value;
        }
        public void Login(){

        }
        public void Logout(){

        }
    }
}