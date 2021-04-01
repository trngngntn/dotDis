using System;
using System.Text.Json.Serialization;

namespace Models{
    public class JsonGeneric{
        private int type;
        private string data;

        public JsonGeneric(int type, string data)
        {
            this.type = type;
            this.data = data;
        }

        [JsonPropertyName("type")]
        public int Type { get => type; set => type = value; }
        [JsonPropertyName("data")]
        public string Data { get => data; set => data = value; }
        
        public override string ToString()
        {
            return "JsonGeneric:" + type + ";" + data + ";";
        }
    }
}