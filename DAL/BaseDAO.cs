using System;
using System.Data;
using MySql.Data.MySqlClient;
using Models;

namespace DAL
{
    public abstract class BaseDAO<T> where T : DBObject<T>
    {
        protected string GetTableName()
        {
            DBTableAttribute attr = (DBTableAttribute)Attribute.GetCustomAttribute(typeof(T), typeof(DBTableAttribute));
            return attr.DbName;
        }
        public void GetAll(params string[] propeties)
        {   
            
        }
        public void Insert()
        {

        }

        public void Delete()
        {

        }

        public void Update()
        {

        }
    }
}