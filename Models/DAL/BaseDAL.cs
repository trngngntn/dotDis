using System;
using System.Data;

namespace dotdis.Models.DAL
{
    public class BaseDAL<T>
    {
        public static void GetAll()
        {
            string sql = "SELECT * FROM Test";
            DataTable temp = Database.GetData(sql);
            foreach (DataRow row in temp.Rows)
            {
                int id = Int32.Parse(row["id"].ToString());
                string name = row["name"].ToString();
                Console.WriteLine("ID:{0};Name:{1}", id, name);
            }
        }

        public void Get()
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