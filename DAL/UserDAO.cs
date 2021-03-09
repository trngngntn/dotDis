using System;
using System.Data;
using MySql.Data.MySqlClient;
using dotdis.Models;
using dotdis.Util;

namespace dotdis.DAL
{
    public class UserDAO
    {
        public static void GetAll()
        {
            string sql = "SELECT * FROM Test";
            DataTable temp = Database.GetData(sql);
            foreach (DataRow row in temp.Rows)
            {
                int id = Int32.Parse(row["id"].ToString());
                string name = row["name"].ToString();
                Console.WriteLine("ID:{0};Name:{1}", id, name);
            }
        }
        public static int CreateNewUser(string name, string email, string username, string passwd)
        {
            string salt = Cryptor.GenerateSalt();
            string pwd = Cryptor.GenerateHash(passwd, salt);
            string sql = "INSERT INTO `User`(`username`,`fullname`,`email`,`salt`,`pwd`) "
            + "VALUES(@username,@name,@email,@salt,@pwd)";
            MySqlParameter[] param = new MySqlParameter[] {
                new MySqlParameter("username", MySqlDbType.VarChar),
                new MySqlParameter("name", MySqlDbType.VarChar),
                new MySqlParameter("email", MySqlDbType.VarChar),
                new MySqlParameter("salt", MySqlDbType.String),
                new MySqlParameter("pwd", MySqlDbType.String)
            };
            Console.WriteLine(username + " " + name + " " + email + " " + salt + " " + pwd);
            param[0].Value = username;
            param[1].Value = name;
            param[2].Value = email;
            param[3].Value = salt;
            param[4].Value = pwd;
            return Database.ExecuteSQL(sql, param);
        }

        internal static string GetSalt(int id)
        {
            string sql = "SELECT `salt` FROM `User` WHERE `id`=@id";
            MySqlParameter param = new MySqlParameter("id", MySqlDbType.Int32);
            param.Value = id.ToString();
            DataTable dat = Database.GetData(sql, param);
            return dat.Rows[0]["salt"].ToString();
        }

        public static int ComparePwd(int id, string pwd)
        {
            string sql = "SELECT COUNT(`id`) FROM `User` WHERE `id`=@id AND `pwd`=@pwd";
            MySqlParameter[] param = new MySqlParameter[] {
                new MySqlParameter("id", MySqlDbType.Int32),
                new MySqlParameter("pwd", MySqlDbType.String)
            };
            param[0].Value = id.ToString();
            param[1].Value = pwd;
            return Database.GetData(sql, param).Rows.Count;
        }

        public static User GetUserByUsername(string username)
        {
            string sql = "SELECT `id`,`fullname` FROM `User` WHERE `username`=@uid";
            MySqlParameter param = new MySqlParameter("uid", MySqlDbType.VarChar);
            param.Value = username;
            DataTable dat = Database.GetData(sql, param);
            if (dat.Rows.Count == 0) return null;
            else
            {
                User user = new User(Int32.Parse(dat.Rows[0]["id"].ToString()),
                dat.Rows[0]["fullname"].ToString());
                return user;
            }
        }

        public void GetUserByEmail()
        {

        }

        public void Insert()
        {

        }

        public void Delete()
        {

        }

        public void Update()
        {

        }
    }
}