using System;
using MySql.Data.MySqlClient;

namespace Models
{
    public class DBPropertyAttribute : Attribute
    {
        private string dbName;
        private MySqlDbType dbType;
        public DBPropertyAttribute(string dbName, MySqlDbType dbType)
        {
            this.dbName = dbName;
            this.dbType = dbType;
        }

        public string DbName { get => "`" + dbName + "`"; }
        public MySqlDbType DbType { get => dbType; }
    }
}