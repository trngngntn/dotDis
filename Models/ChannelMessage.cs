using System;

namespace Models{
    public class ChannelMessage:Message{
        private string channelID;
        public string ChannelID { get => channelID; set => channelID = value; }
    }
}