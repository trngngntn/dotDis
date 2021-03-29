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
        public Room GetById(int id)
        {
            string sql = "SELECT `id`,`name` FROM `Room` WHERE `id`=@id";
            MySqlParameter param = new MySqlParameter("id", MySqlDbType.Int32);
            param.Value = id;
            DataTable dat = Database.GetData(sql, param);
            DataRow row = dat.Rows[0];
            return new Room(Int32.Parse(row["id"].ToString()), row["name"].ToString(), -1);
        }

        public List<Room> GetByUserId(int uid)
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

        //Create method
        public void Create(string name, int owner)
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

    }
}