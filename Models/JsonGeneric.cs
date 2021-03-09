using System;

namespace dotdis.Models{
    public class JsonGeneric{
        private string type;
        private string data;
        public string Type { get => type; set => type = value; }
        public string Data { get => data; set => data = value; }
    }
}