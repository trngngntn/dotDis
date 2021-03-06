using System;
using System.Collections.Generic;
using dotdis.Util;

namespace dotdis.Models
{
    public class User
    {
        private static HashSet<User> activeUser;
        private string id;
        private string name;
        private string email;
        private string salt;
        private int status;
        public User(string id, string name, string email, string salt)
        {
            this.id = id;
            this.name = name;
            this.email = email;
            this.salt = salt;
        }

        public User(string id, string name)
        {
            this.id = id;
            this.name = name;
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
        public string Salt
        {
            get => salt;
        }
        public void Login(string password){
            
        }
        public void Logout(){

        }
    }
}