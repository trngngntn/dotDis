using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using DAL;

namespace Models{
    public class PrivateMessage:Message{
        private int recvID;

        public PrivateMessage(int id, int sendID, int recvID, DateTime created, string detail) 
        {
            base.Id = id;
            base.SendID = sendID;
            this.recvID = recvID;
            base.Created = created;
            base.Detail = detail;
        }

        [JsonPropertyName("recvId")]
        public int RecvID { get => recvID; set => recvID = value; }

        public int SendPrivateMessage() {
            this.Created = new DateTime();
            // return MessageDAO.CreatePrivateMessage(SendID, RecvID, Detail);
            return 0;
        }

        public static List<PrivateMessage> GetMessages(int recvId) {
            return MessageDAO.GetMessages(recvId);
        }
    }
}