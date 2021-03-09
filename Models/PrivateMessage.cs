using System;

namespace dotdis.Models{
    public class PrivateMessage:Message{
        private int recvID;
        public int RecvID { get => recvID; set => recvID = value; }
    }
}