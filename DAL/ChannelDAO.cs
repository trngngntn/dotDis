using System;
using System.Collections.Generic;
using System.Data;
using MySql.Data;
using MySql.Data.MySqlClient;
using Models;
using Extensions;
using Utils;

namespace DAL
{
    public class ChannelDAO
    {

        public static int CreateDefaultConversation(int roomId)
        {
            return Create(roomId, "General", 1);
        }
        public static int CreateDefaultVoiceChannel(int roomId)
        {
            return Create(roomId, "General", 2);
        }
        public static int GetUserPermission(int channelId, int uid)
        {

            return 0;
        }
        public static int Create(int roomId, string name, int type)
        {
            string sql = "INSERT INTO `Channel`(`room_id`, `name`, `type`) VALUES (@roomId, @name, @type)";
            MySqlParameter[] param = new MySqlParameter[] {
                new MySqlParameter("@roomId", MySqlDbType.Int32),
                new MySqlParameter("@name", MySqlDbType.VarChar),
                new MySqlParameter("@type", MySqlDbType.Int32)
            };
            param[0].Value = roomId;
            param[1].Value = name;
            param[2].Value = type;
            int result = Database.ExecuteSQL(sql, param);
            return result;
        }

        public static List<Channel> Get(int roomId, int uid)
        {
            string sql = "SELECT `id`,`name`,`type` FROM `Channel` WHERE `room_id` = @roomId";
            MySqlParameter param = new MySqlParameter("roomId", MySqlDbType.Int32);
            param.Value = roomId;
            DataTable dat = Database.GetData(sql, param);
            List<Channel> result = new List<Channel>();
            foreach (DataRow row in dat.Rows)
            {
                int id = row["id"].ToString().ToInt();
                string name = row["name"].ToString();
                int type = row["type"].ToString().ToInt();
                result.Add(new Channel(id, roomId, name, type));
            }
            return result;
        }

        public static int GetRoomId(int channelId) // need edit with permission
        {
            string sql = "SELECT `room_id` FROM `Channel` WHERE `id` = @channelId";
            MySqlParameter param = new MySqlParameter("channelId", MySqlDbType.Int32);
            param.Value = channelId;
            DataTable dat = Database.GetData(sql, param);
            return dat.Rows[0]["room_id"].ToString().ToInt();
        }
        public static List<int> GetAccessibleUID(int channelId) // need edit with permission
        {
            int roomId = GetRoomId(channelId);
            ConsoleLogger.Warn(roomId + " is active");
            return RoomDAO.GetMembersUID(roomId);
        }
    }
}