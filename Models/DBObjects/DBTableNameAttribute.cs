using System;
using MySql.Data.MySqlClient;

namespace Models
{
    public class DBTableAttribute : Attribute
    {
        private string dbName;
        public DBTableAttribute(string dbName)
        {
            this.dbName = dbName;
        }

        public string DbName { get => "`" + dbName + "`"; }
    }
}