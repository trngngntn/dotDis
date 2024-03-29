using System;
using System.Data;
using MySql.Data.MySqlClient;
using Models;
using Utils;
using System.Collections.Generic;
using Extensions;

namespace DAL
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
            //Console.WriteLine(username + " " + name + " " + email + " " + salt + " " + pwd);
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
            string sql = "SELECT `id` FROM `User` WHERE `id`=@id AND `pwd`=@pwd";
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

        public static User GetUserByID(int uid)
        {
            string sql = "SELECT `id`,`fullname` FROM `User` WHERE `id`=@uid";
            MySqlParameter param = new MySqlParameter("uid", MySqlDbType.Int32);
            param.Value = uid;
            DataTable dat = Database.GetData(sql, param);
            if (dat.Rows.Count == 0) return null;
            else
            {
                User user = new User(Int32.Parse(dat.Rows[0]["id"].ToString()),
                dat.Rows[0]["fullname"].ToString());
                return user;
            }
        }

        public static User GetUserByEmail(string email)
        {
            string sql = "SELECT `id`,`fullname` FROM `User` WHERE `email`=@email";
            MySqlParameter param = new MySqlParameter("uid", MySqlDbType.VarChar);
            param.Value = email;
            DataTable dat = Database.GetData(sql, param);
            if (dat.Rows.Count == 0) return null;
            else
            {
                User user = new User(Int32.Parse(dat.Rows[0]["id"].ToString()),
                dat.Rows[0]["fullname"].ToString());
                return user;
            }
        }

        public static List<int> ListFriendUid(int uid)
        {
            string sql = "SELECT * FROM `Friend` WHERE uid1=@uid OR uid2=@uid";
            MySqlParameter param = new MySqlParameter("uid", MySqlDbType.Int32);
            param.Value = uid;
            DataTable dat = Database.GetData(sql, param);
            List<int> fUids = new List<int>();
            foreach (DataRow row in dat.Rows)
            {
                int tmpUid = Int32.Parse(row["uid1"].ToString());
                fUids.Add(tmpUid == uid ? Int32.Parse(row["uid2"].ToString()) : tmpUid);
            }

            return fUids;
        }

        public static List<User> ListFriend(int uid)
        {
            List<int> fUids = ListFriendUid(uid);
            List<User> friend = new List<User>();
            foreach (int fUid in fUids)
            {
                friend.Add(GetUserByID(fUid));
            }
            return friend;
        }

        public static void AddFriend(int uid, int fuid)
        {
            ConsoleLogger.Warn(uid + " " + fuid);
            string sql = "INSERT INTO `Friend`(uid1,uid2,status) VALUES(@uid,@fuid,0)";
            MySqlParameter[] param = {
                new MySqlParameter("uid", MySqlDbType.Int32),
                new MySqlParameter("fuid", MySqlDbType.Int32)
            };
            param[0].Value = uid;
            param[1].Value = fuid;
            Database.ExecuteSQL(sql, param);
        }

        public static List<Room> ListRoom(int uid)
        {
            string sql = "SELECT * FROM `Room_User` INNER JOIN `Room` ON `Room`.`id` = `Room_User`.`room_id` "
            + "WHERE `Room_User`.`uid` = @uid ";
            MySqlParameter param = new MySqlParameter("uid", MySqlDbType.Int32);
            param.Value = uid;
            DataTable dat = Database.GetData(sql, param);
            List<Room> result = new List<Room>();
            foreach (DataRow row in dat.Rows)
            {
                int id = row["id"].ToString().ToInt();
                string name = row["name"].ToString();
                result.Add(new Room(id, name, -1));
            }
            return result;
        }

        public static List<User> Find(int uid, string str)
        {
            string sql = "SELECT DISTINCT `id`, `fullname`, `username` FROM `User` WHERE `id` NOT IN "
            + "(SELECT DISTINCT `id` FROM `User` INNER JOIN (SELECT `uid1`,`uid2` FROM `Friend` WHERE `uid1` = @uid OR `uid2` = @uid) `tbl` "
            + " ON `User`.`id`=`tbl`.`uid1` OR `User`.`id`=`tbl`.`uid2`) AND (`fullname` LIKE @pattern OR `username` LIKE @pattern)";
            MySqlParameter[] param = { new MySqlParameter("pattern", MySqlDbType.VarChar), new MySqlParameter("uid", MySqlDbType.Int32) };
            param[0].Value = "%" + str + "%";
            param[1].Value = uid;
            DataTable dat = Database.GetData(sql, param);
            List<User> result = new List<User>();
            foreach (DataRow row in dat.Rows)
            {
                int id = row["id"].ToString().ToInt();
                string name = row["fullname"].ToString();
                string username = row["username"].ToString();
                result.Add(new User(id, name, username));
            }
            return result;
        }

        public static int CountAllUsers()
        {
            string sql = "SELECT COUNT(*) FROM `User`;";
            DataTable dat = Database.GetData(sql);
            int result = Int32.Parse(dat.Rows[0][0].ToString());
            return result;
        }
    }
}