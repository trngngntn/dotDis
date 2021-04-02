using System;
using System.Data;
using MySql.Data;
using MySql.Data.MySqlClient;
using System.Collections.Generic;
using Utils;

namespace DAL
{
    public class Database
    {
        /// <summary>
        /// 
        /// </summary>
        public static MySqlConnection GetConnection()
        {
            //String connectionStr = "server=[serverAddr];user=[username];database=[DBName];port=[DBport];password=[pass]";
            String connectionStr = "server=dotdis.duckdns.org;user=sa;database=dotDis;port=3306;password=Luan-2000";
            MySqlConnection connection = new MySqlConnection(connectionStr);
            return connection;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sql"></param>
        /// <return>DataTable</return>
        public static DataTable GetData(string sql, params MySqlParameter[] args){
            try{
                MySqlCommand command = new MySqlCommand(sql, GetConnection());
                command.Parameters.AddRange(args);
                MySqlDataAdapter dataAdapter = new MySqlDataAdapter();
                dataAdapter.SelectCommand = command;
                DataSet dataSet = new DataSet();
                dataAdapter.Fill(dataSet);
                return dataSet.Tables[0];
            } catch(Exception){
                ConsoleLogger.Error("Database error");
            }
            return null;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="args"></param>
        /// <return>int</return>
        public static int ExecuteSQL(string sql, params MySqlParameter[] args){
            MySqlCommand command = new MySqlCommand(sql, GetConnection());
            command.Parameters.AddRange(args);
            command.Connection.Open();
            int affectedRows = command.ExecuteNonQuery();
            command.Connection.Close();
            return affectedRows;
        }

        public static List<string> GetTables() {
            List<string> list = new List<string>();
            string sql = "show tables;";
            DataTable dat = GetData(sql);
            foreach (DataRow row in dat.Rows) {
                list.Add(row[0].ToString());
            }
            return list;
        }
    }
}