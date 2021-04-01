using System;
using System.Data;
using MySql.Data;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using Models;

namespace DAL
{
    public class MessageDAO
    {
        
        public static int CreatePrivateMessage(int sendID, int recvID, string detail)
        {
            string sql = "insert into `Private_Mesg`(`send_id`, `recv_id`, detail) values (@sendId, @recvId, @detail)";
            MySqlParameter[] param = new MySqlParameter[] {
                new MySqlParameter("@sendId", MySqlDbType.Int32),
                new MySqlParameter("@recvId", MySqlDbType.Int32),
                new MySqlParameter("@detail", MySqlDbType.VarChar)
            };

            param[0].Value = sendID;
            param[1].Value = recvID;
            param[2].Value = detail;

            int result = Database.ExecuteSQL(sql, param);
            return result;

        }

        public static int CreateChannelMessage(int sendID, int channelID, string detail)
        {
            string sql = "insert into `Channel_Mesg`(`send_id`, `channel_id`, `detail`) values (@sendId, @channelId, @detail)";
            MySqlParameter[] param = new MySqlParameter[] {
                new MySqlParameter("@sendId", MySqlDbType.Int32),
                new MySqlParameter("@channelId", MySqlDbType.Int32),
                new MySqlParameter("@detail", MySqlDbType.VarChar)
            };

            param[0].Value = sendID;
            param[1].Value = channelID;
            param[2].Value = detail;

            int result = Database.ExecuteSQL(sql, param);
            return result;
        }

        public static int CountAllPrivateMessage() {
            string countPrivate = "SELECT COUNT(*) FROM `Private_Mesg`;";
            DataTable dat1 = Database.GetData(countPrivate);
            int prvt = Int32.Parse(dat1.Rows[0][0].ToString());
            return prvt;
        }

        public static int CountAllChannelMessage()
        {
            string countChannel = "SELECT COUNT(*) FROM `Channel_Mesg`;";
            DataTable dat2 = Database.GetData(countChannel);
            int chnl = Int32.Parse(dat2.Rows[0][0].ToString());
            return chnl;
        }

        

        public static List<PrivateMessage> GetMessages(int recvId)
        {
            List<PrivateMessage> list = new List<PrivateMessage>();

            string sql = "select * from `Private_Mesg` where `recv_id`=@recvId;";
            MySqlParameter param = new MySqlParameter("@recvId", MySqlDbType.Int32);
            param.Value = recvId;

            DataTable dat = Database.GetData(sql, param);
            foreach(DataRow row in dat.Rows) {
                int id = Int32.Parse(row["id"].ToString());
                int sendId = Int32.Parse(row["send_id"].ToString());
                DateTime created = DateTime.Parse(row["created"].ToString());
                string detail = row["detail"].ToString();

                PrivateMessage pm = new PrivateMessage(id, sendId, recvId, created, detail);
                list.Add(pm);
            }


            return list;
        }
    }
}