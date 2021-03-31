using System;
using DAL;
using MySql.Data.MySqlClient;

namespace Models
{
    [DBTable("Room")]
    public class Room : DBObject<Room>
    {
        private int id;
        private string name;
        private int ownerID;

        public Room(int id, string name, int ownerID)
        {
            this.id = id;
            this.name = name;
            this.ownerID = ownerID;
        }

        [DBProperty("id", MySqlDbType.Int32)]
        public int ID { get => id; set => id = value; }

        [DBProperty("name", MySqlDbType.VarChar)]
        public string Name { get => name; set => name = value; }

        [DBProperty("owner_id", MySqlDbType.Int32)]
        public int OwnerID { get => ownerID; set => ownerID = value; }

        public static int CountAllRooms()
        {
            return RoomDAO.CountAllRooms();
        }
    }
}