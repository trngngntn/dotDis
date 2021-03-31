using System;
using System.Collections.Generic;
using System.Data;
using Models;
using Utils;
using MySql.Data.MySqlClient;

namespace DAL
{
    public class ChannelMessageDAO
    {
        /// <summary>
        ///     Retrives list of private message from database starting from provided index.
        /// </summary>
        /// <param name="uid1"></param>
        /// <param name="uid2"></param>
        /// <param name="index"></param>
        /// <return>List<PrivateMessage></return>
        public static List<ChannelMessage> Get(int channelId, int index)
        {
            string sql = "SELECT * FROM `Channel_Mesg` "
            + "WHERE `channel_id` = @channelId "
            + "ORDER BY `created` DESC, `id` DESC "
            + "LIMIT @index, 25;";
            MySqlParameter[] param = new MySqlParameter[] {
                new MySqlParameter("channelId", MySqlDbType.Int32),
                new MySqlParameter("index", MySqlDbType.Int32)
            };
            param[0].Value = channelId;
            param[1].Value = index;
            List<ChannelMessage> result = new List<ChannelMessage>(25);
            DataTable dat = Database.GetData(sql, param);
            foreach (DataRow row in dat.Rows)
            {
                int id = Int32.Parse(row["id"].ToString());
                int sendId = Int32.Parse(row["send_id"].ToString());
                DateTime created = DateParser.Parse(row["created"].ToString());
                string detail = row["detail"].ToString();
                result.Add(new ChannelMessage(id, sendId, channelId, created, detail));
            }
            return result;
        }


    }
}
