using System;
using System.Text.Json.Serialization;

namespace dotdis.Models{
    public class JsonGeneric{
        private string type;
        private string data;

        public JsonGeneric(string type, string data)
        {
            this.type = type;
            this.data = data;
        }

        [JsonPropertyName("type")]
        public string Type { get => type; set => type = value; }
        [JsonPropertyName("data")]
        public string Data { get => data; set => data = value; }
        public override string ToString()
        {
            return "JsonGeneric:" + type + ";" + data + ";";
        }
    }
}