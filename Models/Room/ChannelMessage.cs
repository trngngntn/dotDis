using System;
using System.Text.Json.Serialization;
using DAL;

namespace Models
{
    public class ChannelMessage : Message
    {
        private int channelID;

        public ChannelMessage(int id, int send_id, int channelID, DateTime created, string detail)
        {
            base.Id = id;
            base.SendID = send_id;
            this.channelID = channelID;
            base.Created = created;
            base.Detail = detail;
        }

        public ChannelMessage(int send_id, int channelID, string detail)
        {
            base.SendID = send_id;
            this.channelID = channelID;
            base.Detail = detail;
        }

        public ChannelMessage()
        {
        }

        [JsonPropertyName("channelId")]
        public int ChannelID { get => channelID; set => channelID = value; }

        public int SendChannelMessage()
        {
            return MessageDAO.CreateChannelMessage(SendID, ChannelID, Detail);
        }

    }
}