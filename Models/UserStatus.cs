using System;
using System.Text.Json.Serialization;

namespace dotDis.Models{
    public class UserStatus{
        private int id;
        private int status;
        public UserStatus(int id, int status){
            this.id = id;
            this.status = status;
        }
        [JsonPropertyName("id")]
        public int Id { get => id; set => id = value; }
        [JsonPropertyName("status")]
        public int Status { get => status; set => status = value; }
    }
}