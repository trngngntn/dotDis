using System;
using System.Collections.Generic;
using DAL;

namespace Models{
    public class Channel{
        private int id;
        private int roomID;
        private string name;
        private int type;

        public Channel(int id, int roomID, string name, int type)
        {
            this.id = id;
            this.roomID = roomID;
            this.name = name;
            this.type = type;
        }

        public int Id { get => id; set => id = value; }
        public int RoomID { get => roomID; set => roomID = value; }
        public string Name { get => name; set => name = value; }
        public int Type { get => type; set => type = value; }

        public static int CreateChannel(int roomId, string name, int type) {
            return ChannelDAO.CreateChannel(roomId, name, type);
        }
    }
}