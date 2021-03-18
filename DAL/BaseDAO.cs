using System;
using System.Data;
using MySql.Data.MySqlClient;
using Models;

namespace DAL
{
    public abstract class BaseDAO<T> where T : DBObject<T>
    {
        protected abstract string GetTableName();
        protected string C(string str)
        {
            return "`" + str + "`";
        }
        public void GetAll(params string[] propeties)
        {
            String sql = "SELECT ";
            for (int i = 0; i < propeties.Length; i++)
            {
                sql += C(propeties[i]);
                if (i < propeties.Length)
                {
                    
                }
            }


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