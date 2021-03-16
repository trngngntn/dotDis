using System;
using System.Data;
using MySql.Data.MySqlClient;
using Models;
using Utils;
using System.Collections.Generic;

namespace DAL
{
    public class AdminDAO
    {

        public static Admin GetAdminByUsername(string username)
        {
            string sql = "SELECT `id`,`displayName` FROM `Admin` WHERE `username`=@uid";
            MySqlParameter param = new MySqlParameter("uid", MySqlDbType.VarChar);
            param.Value = username;
            DataTable dat = Database.GetData(sql, param);
            if (dat.Rows.Count == 0) return null;
            else
            {
                Admin user = new Admin(Int32.Parse(dat.Rows[0]["id"].ToString()),
                dat.Rows[0]["displayName"].ToString());
                return user;
            }
        }

        public static Admin GetAdminByID(int uid)
        {
            string sql = "SELECT `id`,`fullname` FROM `Admin` WHERE `id`=@uid";
            MySqlParameter param = new MySqlParameter("uid", MySqlDbType.Int32);
            param.Value = uid;
            DataTable dat = Database.GetData(sql, param);
            if (dat.Rows.Count == 0) return null;
            else
            {
                Admin user = new Admin(Int32.Parse(dat.Rows[0]["id"].ToString()),
                dat.Rows[0]["displayName"].ToString());
                return user;
            }
        }
        internal static string GetSalt(int id)
        {
            string sql = "SELECT `salt` FROM `Admin` WHERE `id`=@id";
            MySqlParameter param = new MySqlParameter("id", MySqlDbType.Int32);
            param.Value = id.ToString();
            DataTable dat = Database.GetData(sql, param);
            return dat.Rows[0]["salt"].ToString();
        }

        public static int ComparePwd(int id, string pwd)
        {
            string sql = "SELECT `id` FROM `Admin` WHERE `id`=@id AND `pwd`=@pwd";
            MySqlParameter[] param = new MySqlParameter[] {
                new MySqlParameter("id", MySqlDbType.Int32),
                new MySqlParameter("pwd", MySqlDbType.String)
            };
            param[0].Value = id.ToString();
            param[1].Value = pwd;
            return Database.GetData(sql, param).Rows.Count;
        }
    }
}