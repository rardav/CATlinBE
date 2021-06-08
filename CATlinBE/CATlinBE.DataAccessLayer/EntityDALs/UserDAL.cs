using CATlinBE.DataAccessLayer.Interfaces;
using CATlinBE.Entities;
using Microsoft.Extensions.Configuration;
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
                    //Username = reader["Username"].ToString(),
                    Email = reader["Email"].ToString(),
                    FirstName = reader["FirstName"].ToString(),
                    LastName = reader["LastName"].ToString(),
                    PasswordHash = (byte[])reader["PasswordHash"],
                    PasswordSalt = (byte[])reader["PasswordSalt"],
                //InstitutionId = Convert.ToInt64(reader["InstitutionId"].ToString()),
                    RoleId = Convert.ToInt64(reader["RoleId"].ToString())
            };
                   
                users.Add(user);
            }

            return users;
        }

        public bool UserExists(string email)
        {
            var SQL = "SELECT COUNT(*) FROM Users WHERE email = @email";

            using var sqlConn = GetSqlConnection();
            using var sqlCmd = GetSqlCommand(SQL, sqlConn);

            sqlCmd.Parameters.Add("email", SqlDbType.VarChar).Value = email;
            sqlConn.Open();

            var count = (int)sqlCmd.ExecuteScalar();

            return count == 1;
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

        public void RegisterUser(User user)
        {
            var SQL = "INSERT INTO Users (Email, FirstName, LastName, PasswordHash, PasswordSalt) VALUES (@Email, @FirstName, @LastName, @PasswordHash, @PasswordSalt)";

            using var sqlConn = GetSqlConnection();
            using var sqlCmd = GetSqlCommand(SQL, sqlConn);

            sqlConn.Open();

            sqlCmd.Parameters.Add("@Email", SqlDbType.VarChar).Value = user.Email;
            sqlCmd.Parameters.Add("@FirstName", SqlDbType.VarChar).Value = user.FirstName;
            sqlCmd.Parameters.Add("@LastName", SqlDbType.VarChar).Value = user.LastName;
            sqlCmd.Parameters.Add("@PasswordHash", SqlDbType.VarBinary).Value = user.PasswordHash;
            sqlCmd.Parameters.Add("@PasswordSalt", SqlDbType.VarBinary).Value = user.PasswordSalt;

            sqlCmd.ExecuteNonQuery();
        }

        public User GetUserByEmail(string email)
        {
            var SQL = "SELECT * FROM Users WHERE email = @email";

            using var sqlConn = GetSqlConnection();
            using var sqlCmd = GetSqlCommand(SQL, sqlConn);

            sqlCmd.Parameters.Add("email", SqlDbType.VarChar).Value = email;
            sqlConn.Open();

            using var reader = sqlCmd.ExecuteReader();
            var user = new User();
            while (reader.Read())
            {
                user.Id = Convert.ToInt64(reader["Id"].ToString());
                //Username = reader["Username"].ToString(),
                user.Email = reader["Email"].ToString();
                user.FirstName = reader["FirstName"].ToString();
                user.LastName = reader["LastName"].ToString();
                user.PasswordHash = (byte[])reader["PasswordHash"];
                user.PasswordSalt = (byte[])reader["PasswordSalt"];
                //InstitutionId = Convert.ToInt64(reader["InstitutionId"].ToString()),
                user.RoleId = Convert.ToInt64(reader["RoleId"].ToString());
            }

            return user;
        }

        public User GetUserById(long id)
        {
            var SQL = "SELECT * FROM Users WHERE Id = @id";

            using var sqlConn = GetSqlConnection();
            using var sqlCmd = GetSqlCommand(SQL, sqlConn);

            sqlCmd.Parameters.Add("id", SqlDbType.BigInt).Value = id;
            sqlConn.Open();

            using var reader = sqlCmd.ExecuteReader();
            var user = new User();
            while (reader.Read())
            {
                user.Id = Convert.ToInt64(reader["Id"].ToString());
                //Username = reader["Username"].ToString(),
                user.Email = reader["Email"].ToString();
                user.FirstName = reader["FirstName"].ToString();
                user.LastName = reader["LastName"].ToString();
                user.PasswordHash = (byte[])reader["PasswordHash"];
                user.PasswordSalt = (byte[])reader["PasswordSalt"];
                //InstitutionId = Convert.ToInt64(reader["InstitutionId"].ToString()),
                user.RoleId = Convert.ToInt64(reader["RoleId"].ToString());
            }

            return user;
        }

        public long GetIdFromEmail(string email)
        {
            var SQL = "SELECT Id FROM Users WHERE email = @email";

            using var sqlConn = GetSqlConnection();
            using var sqlCmd = GetSqlCommand(SQL, sqlConn);

            sqlCmd.Parameters.Add("email", SqlDbType.VarChar).Value = email;
            sqlConn.Open();

            using var reader = sqlCmd.ExecuteReader();
            long id = 0;
            while (reader.Read())
            {
                id = Convert.ToInt64(reader["Id"].ToString());
            }

            sqlConn.Close();
            return id;
        }
    }
}
