using System;
using System.Data;
using System.Collections.Generic;
using Models;
using MySql.Data.MySqlClient;
using Extensions;

namespace DAL
{
    public class RoleDAO
    {
        //Get methods
        private const int PERM_DEFAULT = 0;
        public static int? GetPermissionInRoom(int roleId)
        {
            string sql = "SELECT `perm` FROM `Role` WHERE `id`=@id";
            MySqlParameter param = new MySqlParameter("id", MySqlDbType.Int32);
            param.Value = roleId;
            DataTable dat = Database.GetData(sql, param);
            if (dat.Rows.Count == 0)
            {
                return null;
            }
            else
            {
                return dat.Rows[0]["perm"].ToString().ToInt();
            }
        }

        public static int? GetPermissonByChannel(int roleId, int channelId)
        {
            string sql = "SELECT `type` FROM `Permission` "
            + "WHERE `role_id`=@roleId AND `channel_id`=@channelId";
            MySqlParameter[] param = {
                new MySqlParameter("roleId", MySqlDbType.Int32),
                new MySqlParameter("roleId", MySqlDbType.Int32)
            };
            param[0].Value = roleId;
            param[1].Value = channelId;
            DataTable dat = Database.GetData(sql, param);
            if (dat.Rows.Count == 0)
            {
                return null;
            }
            else
            {
                return dat.Rows[0]["perm"].ToString().ToInt();
            }
        }
        /// Create methods
        public static void CreateDefaut(int roomId)
        {
            Create(roomId, "Everyone", PERM_DEFAULT);
        }
        public static void Create(int roomId, string name, int perm)
        {
            string sql = "INSERT INTO `Role`(`room_id`,`name`,`perm`) VALUES(@roomId,@name,@perm)";
            MySqlParameter[] param = {
                new MySqlParameter("roomId", MySqlDbType.Int32),
                new MySqlParameter("name", MySqlDbType.VarChar),
                new MySqlParameter("parm", MySqlDbType.Int32)
            };
            param[0].Value = roomId;
            param[1].Value = name;
            param[2].Value = perm;
            Database.ExecuteSQL(sql, param);
        }
        /// Update methods
        public static void UpdateName(int roleId, string name)
        {
            
        }

        public static void UpdatePerm()
        {

        }
    }
}