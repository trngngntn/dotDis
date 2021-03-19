using System;
using System.Data;
using System.Collections.Generic;
using Models;

namespace DAL
{
    public class RoomDAO
    {
        public static int CountAllRooms()
        {
            string sql = "SELECT COUNT(*) FROM `Room`;";
            DataTable dat = Database.GetData(sql);
            int result = Int32.Parse(dat.Rows[0][0].ToString());
            return result;
        }

        public static Room GetRoomById(int roomId) {
            string sql = "SELECT * FROM `Room` WHERE `id`={0}";
            string.Format(sql, roomId);
            DataTable dat = Database.GetData(sql);

            int id = Int32.Parse(dat.Rows[0]["id"].ToString());
            string name = dat.Rows[0]["name"].ToString();
            int ownerId = Int32.Parse(dat.Rows[0]["owner_id"].ToString());

            Room r = new Room(id, name, ownerId);
            return r;
        }

        public static List<Channel> GetAllChannelsInRoom(int roomId) {
            string sql = "SELECT `id`, `name`, `type` FROM `Channel` WHERE `room_id`={0}";
            string.Format(sql, roomId);

            DataTable dat = Database.GetData(sql);
            List<Channel> list = new List<Channel>();
            foreach (DataRow row in dat.Rows) {
                int id = Int32.Parse(row["id"].ToString());
                string name = row["name"].ToString();
                int type = Int32.Parse(row["type"].ToString());

                Channel c = new Channel(id, roomId, name, type);
                list.Add(c);
            }
            return list;
        }

        
    }
}