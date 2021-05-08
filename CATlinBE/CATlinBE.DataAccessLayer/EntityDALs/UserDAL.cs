using CATlinBE.DataAccessLayer.Interfaces;
using CATlinBE.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace CATlinBE.DataAccessLayer.EntityDALs
{
    public class UserDAL : BaseDAL, IUserDAL
    {
        public List<User> GetAllUsers()
        {
            var users = new List<User>();
            var SQL = "SELECT * FROM Users";

            using var sqlConn = GetSqlConnection();
            using var sqlCmd = GetSqlCommand(SQL, sqlConn);

            sqlConn.Open();

            using var reader = sqlCmd.ExecuteReader();

            while (reader.Read())
            {
                var user = new User
                {
                    Id = Convert.ToInt64(reader["Id"].ToString()),
                    Username = reader["Username"].ToString(),
                    Email = reader["Email"].ToString(),
                    FirstName = reader["FirstName"].ToString(),
                    LastName = reader["LastName"].ToString(),
                    InstitutionId = Convert.ToInt64(reader["InstitutionId"].ToString()),
                    RoleId = Convert.ToInt64(reader["RoleId"].ToString())
                };
                   
                users.Add(user);
            }

            return users;
        }

        public void InsertUser(User user)
        {
            var SQL = "INSERT INTO Users (Username, Email, FirstName, LastName, InstitutionId, RoleId) VALUES (@Username, @Email, @FirstName, @LastName, @InstitutionId, @RoleId)";

            using var sqlConn = GetSqlConnection();
            using var sqlCmd = GetSqlCommand(SQL, sqlConn);

            sqlConn.Open();

            sqlCmd.Parameters.Add("@Username", SqlDbType.VarChar).Value = user.Username;
            sqlCmd.Parameters.Add("@Email", SqlDbType.VarChar).Value = user.Username;
            sqlCmd.Parameters.Add("@FirstName", SqlDbType.VarChar).Value = user.Username;
            sqlCmd.Parameters.Add("@LastName", SqlDbType.VarChar).Value = user.Username;
            sqlCmd.Parameters.Add("@StartTime", SqlDbType.VarChar).Value = user.Username;
            sqlCmd.Parameters.Add("@InstitutionId", SqlDbType.BigInt).Value = user.InstitutionId;
            sqlCmd.Parameters.Add("@RoleId", SqlDbType.BigInt).Value = user.RoleId;

            sqlCmd.ExecuteNonQuery();
        }
    }
}
