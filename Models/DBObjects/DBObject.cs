using MySql.Data.MySqlClient;

namespace Models
{
    public abstract class DBObject<T>
    {
        /// <summary>
        ///     Returns value for property with specified name of this object
        /// </summary>
        /// <param name="name">Name of the property</param>
        /// <return>T</return>
        public T GetValue(string name)
        {
            return (T)GetType().GetProperty(name).GetValue(this);
        }

        public void SetValue(string name, T value)
        {
            GetType().GetProperty(name).SetValue(this, value);
        }

        public static MySqlParameter Param(string name, object value)
        {
            DBPropertyAttribute attr = GetDBProperty(name);
            MySqlParameter param = new MySqlParameter(attr.DbName, attr.DbType);
            param.Value = value;
            return param;
        }

        public static DBPropertyAttribute GetDBProperty(string name)
        {
            return (DBPropertyAttribute)typeof(T).GetProperty(name).GetCustomAttributes(typeof(DBPropertyAttribute), false)[0];
        }
    }
}