using System;
using DAL;

namespace Models{
    public class Room{
        private int id;
        private string name;
        private int ownerID;

        public Room(int id, string name, int ownerID)
        {
            this.id = id;
            this.name = name;
            this.ownerID = ownerID;
        }

        public int Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public int OwnerID { get => ownerID; set => ownerID = value; }

        public static int CountAllRooms() {
            return RoomDAO.CountAllRooms();
        }
    }
}