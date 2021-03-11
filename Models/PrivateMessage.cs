using System;
using System.Text.Json.Serialization;

namespace Models{
    public class PrivateMessage:Message{
        private int recvID;
        [JsonPropertyName("recvId")]
        public int RecvID { get => recvID; set => recvID = value; }
    }
}