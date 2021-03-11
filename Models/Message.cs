using System;
using System.Text.Json.Serialization;

namespace Models{
    public class Message{
        private string id;
        private int sendID;
        private DateTime created;
        private string detail;
        public string Id { get => id; set => id = value; }
        [JsonPropertyName("sendId")]
        public int SendID { get => sendID; set => sendID = value; }
        public DateTime Created { get => created; set => created = value; }
        [JsonPropertyName("detail")]
        public string Detail { get => detail; set => detail = value; }
    }
}