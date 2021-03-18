using System;
using System.Data;

namespace Models{
    public class DBNameAttribute:Attribute{
        public DBNameAttribute(string dbName, SqlDbType dbType){
            
        }
    }
}