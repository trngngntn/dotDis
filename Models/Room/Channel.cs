using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
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
        [JsonPropertyName("id")]
        public int Id { get => id; set => id = value; }
        [JsonPropertyName("roomId")]
        public int RoomID { get => roomID; set => roomID = value; }
        [JsonPropertyName("name")]
        public string Name { get => name; set => name = value; }
        [JsonPropertyName("type")]
        public int Type { get => type; set => type = value; }
    }
}