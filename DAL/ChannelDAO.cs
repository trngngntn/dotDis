using System;
using System.Collections.Generic;
using System.Data;
using MySql.Data;
using MySql.Data.MySqlClient;
using Models;

namespace DAL {
    public class ChannelDAO {

        public static int CreateDefaultConversation(int roomId)
        {
            return Create(roomId, "General", 1);
        }
        public static int CreateDefaultVoiceChannel(int roomId)
        {
            return Create(roomId, "General", 2);
        }
        public static int Create(int roomId, string name, int type) {
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

        public static void UpdateChannel(int id, int roomId, string name, int type) {

        }

        public static void DeleteChannel(int id) {

        }
    }
}