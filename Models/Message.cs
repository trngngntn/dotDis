using System;
using System.Text.Json.Serialization;
using DAL;

namespace Models{
    public class Message{
        private int id;
        private int sendID;
        private DateTime created;
        private string detail;
        public int Id { get => id; set => id = value; }
        
        [JsonPropertyName("sendId")]
        public int SendID { get => sendID; set => sendID = value; }
        public DateTime Created { get => created; set => created = value; }

        [JsonPropertyName("detail")]
        public string Detail { get => detail; set => detail = value; }

        public static int CountAllPrivateMessage() {
            return MessageDAO.CountAllPrivateMessage();
        }
        public static int CountAllChannelMessage() {
            return MessageDAO.CountAllChannelMessage();
        }
        public static int CountAllMessage() {
            return CountAllChannelMessage() + CountAllPrivateMessage();
        }
    }
}