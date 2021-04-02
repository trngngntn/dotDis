using System;
using System.Collections.Generic;
using System.Data;
using Models;
using Utils;
using MySql.Data.MySqlClient;

namespace DAL
{
    public class PrivateMessageDAO
    {
        /// <summary>
        ///     Retrives list of private message from database starting from provided index.
        /// </summary>
        /// <param name="uid1"></param>
        /// <param name="uid2"></param>
        /// <param name="index"></param>
        /// <return>List<PrivateMessage></return>
        public static List<PrivateMessage> Get(int uid1, int uid2, int index)
        {
            string sql = "SELECT * FROM `Private_Mesg` "
            + "WHERE (`send_id`=@uid1 AND `recv_id`=@uid2) OR (`send_id`=@uid2 AND `recv_id`=@uid1)"
            + "ORDER BY `created` DESC, `id` DESC "
            + "LIMIT @index, 25;";
            MySqlParameter[] param = new MySqlParameter[] {
                new MySqlParameter("uid1", MySqlDbType.Int32),
                new MySqlParameter("uid2", MySqlDbType.Int32),
                new MySqlParameter("index", MySqlDbType.Int32)
            };
            param[0].Value = uid1;
            param[1].Value = uid2;
            param[2].Value = index;
            List<PrivateMessage> result = new List<PrivateMessage>(25);
            DataTable dat = Database.GetData(sql, param);
            foreach(DataRow row in dat.Rows)
            {
                int id = Int32.Parse(row["id"].ToString());
                int sendID = Int32.Parse(row["send_id"].ToString());
                int recvID = sendID == uid1 ? uid2 : uid1;
                DateTime created = DateParser.Parse(row["created"].ToString());
                string detail = row["detail"].ToString();
                result.Add(new PrivateMessage(id, sendID, recvID, created, detail));
            }
            return result;
        }


    }
}