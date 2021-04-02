using System;
using System.Data;
using System.Collections.Generic;
using Models;
using MySql.Data.MySqlClient;
using Extensions;

namespace DAL
{
    public class RoomDAO
    {
        //Get methods
        public static Room GetById(int id)
        {
            string sql = "SELECT `id`,`name` FROM `Room` WHERE `id`=@id";
            MySqlParameter param = new MySqlParameter("id", MySqlDbType.Int32);
            param.Value = id;
            DataTable dat = Database.GetData(sql, param);
            DataRow row = dat.Rows[0];
            return new Room(Int32.Parse(row["id"].ToString()), row["name"].ToString(), -1);
        }

        public static List<Room> GetByUserId(int uid)
        {
            string sql = "SELECT `tb2`.`id`, `tb2`.`name` "
            + "FROM `Room_User` AS `tb1` INNER JOIN `Room` AS `tb2` "
            + "ON `tb1`.`room_id`=`tb2`.`id` "
            + "WHERE `uid`=@uid ;";
            MySqlParameter param = new MySqlParameter("uid", MySqlDbType.Int32);
            param.Value = uid;
            List<Room> result = new List<Room>();
            DataTable dat = Database.GetData(sql, param);
            foreach (DataRow row in dat.Rows)
            {
                result.Add(new Room(Int32.Parse(row["id"].ToString()), row["name"].ToString(), -1));
            }
            return result;
        }

        public static List<int> GetMembersUID(int id)
        {
            string sql = "SELECT `uid` FROM `Room_User` WHERE `room_id` = @roomId";
            MySqlParameter param = new MySqlParameter("roomId", MySqlDbType.Int32);
            param.Value = id;
            DataTable dat = Database.GetData(sql, param);
            List<int> result = new List<int>();
            foreach(DataRow row in dat.Rows)
            {
                result.Add(row["uid"].ToString().ToInt());
            }
            return result;
        }

        //Create method
        public static void Create(string name, int owner)
        {
            string sql = "SELECT AddNewRoom(@name, @owner)";
            MySqlParameter[] param = {
                new MySqlParameter("name", MySqlDbType.VarChar),
                new MySqlParameter("owner", MySqlDbType.Int32)
            };
            param[0].Value = name;
            param[1].Value = owner;
            DataTable dat = Database.GetData(sql, param);
            int roomId = dat.Rows[0].ToString().ToInt();
            //create default channels
            ChannelDAO.CreateDefaultConversation(roomId);
            ChannelDAO.CreateDefaultVoiceChannel(roomId);
            //create default roles
        }



        public static int CountAllRooms()
        {
            string sql = "SELECT COUNT(*) FROM `Room`;";
            DataTable dat = Database.GetData(sql);
            int result = Int32.Parse(dat.Rows[0][0].ToString());
            return result;
        }

        public static List<User> GetMembers(int roomId)
        {
            string sql = "SELECT `id`,`fullname` FROM `Room_User` INNER JOIN `User` ON `Room_User`.`uid` = `User`.`id` "
            + "WHERE `room_id` = @roomId";
            MySqlParameter param = new MySqlParameter("roomId", MySqlDbType.Int32);
            param.Value = roomId;
            DataTable dat = Database.GetData(sql, param);
            List<User> result = new List<User>();
            foreach(DataRow row in dat.Rows)
            {
                int id = row["id"].ToString().ToInt();
                string name = row["fullname"].ToString();
                result.Add(new User(id,name,"",""));
            }
            return result;
        }
    }
}