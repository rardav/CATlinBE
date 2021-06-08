using CATlinBE.DataAccessLayer.Interfaces;
using CATlinBE.Entities;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;

namespace CATlinBE.DataAccessLayer.EntityDALs
{
    public class SessionDAL : BaseDAL, ISessionDAL
    {
        public Session GetSessionById(long id)
        {
            var SQL = "SELECT * FROM Sessions WHERE Id = @id";

            using var sqlConn = GetSqlConnection();
            using var sqlCmd = GetSqlCommand(SQL, sqlConn);

            sqlCmd.Parameters.Add("id", SqlDbType.BigInt).Value = id;
            sqlConn.Open();

            using var reader = sqlCmd.ExecuteReader();
            var session = new Session();
            while (reader.Read())
            {
                session.Id = Convert.ToInt64(reader["Id"].ToString());
                session.StartTime = reader["StartTime"].ToString();
                session.EndTime = reader["EndTime"].ToString();
                session.SupervisorId = Convert.ToInt64(reader["SupervisorId"].ToString());
                session.QuestionnaireId = Convert.ToInt64(reader["QuestionnaireId"].ToString());
                session.AccessKey = reader["AccessKey"].ToString();
            }

            return session;
        }

        public Session GetSessionByAccessKey(string accessKey)
        {
            var SQL = "SELECT * FROM Sessions WHERE AccessKey = @accessKey";

            using var sqlConn = GetSqlConnection();
            using var sqlCmd = GetSqlCommand(SQL, sqlConn);

            sqlCmd.Parameters.Add("accessKey", SqlDbType.NVarChar).Value = accessKey;
            sqlConn.Open();

            using var reader = sqlCmd.ExecuteReader();
            var session = new Session();
            while (reader.Read())
            {
                session.Id = Convert.ToInt64(reader["Id"].ToString());
                session.StartTime = reader["StartTime"].ToString();
                session.EndTime = reader["EndTime"].ToString();
                session.SupervisorId = Convert.ToInt64(reader["SupervisorId"].ToString());
                session.QuestionnaireId = Convert.ToInt64(reader["QuestionnaireId"].ToString());
                session.AccessKey = reader["AccessKey"].ToString();
            }

            return session;
        }

        public List<string> GetAllAccessKeys()
        {
            var SQL = "SELECT AccessKey FROM Sessions";

            using var sqlConn = GetSqlConnection();
            using var sqlCmd = GetSqlCommand(SQL, sqlConn);

            sqlConn.Open();

            using var reader = sqlCmd.ExecuteReader();
            var keys = new List<string>();
            while (reader.Read())
            {
                keys.Add(reader["AccessKey"].ToString());
            }

            return keys;
        }

        public void InsertSession(Session session)
        {
            var SQL = "INSERT INTO Sessions (StartTime, EndTime, SupervisorId, QuestionnaireId, AccessKey) VALUES (@StartTime, @EndTime, @SupervisorId, @QuestionnaireId, @AccessKey)";

            using var sqlConn = GetSqlConnection();
            using var sqlCmd = GetSqlCommand(SQL, sqlConn);

            sqlConn.Open();

            sqlCmd.Parameters.Add("@StartTime", SqlDbType.DateTime).Value = DateTime.Parse(session.StartTime);
            sqlCmd.Parameters.Add("@EndTime", SqlDbType.DateTime).Value = DateTime.Parse(session.EndTime);
            sqlCmd.Parameters.Add("@SupervisorId", SqlDbType.BigInt).Value = session.SupervisorId;
            sqlCmd.Parameters.Add("@QuestionnaireId", SqlDbType.BigInt).Value = session.QuestionnaireId;
            sqlCmd.Parameters.Add("@AccessKey", SqlDbType.NVarChar).Value = session.AccessKey;

            sqlCmd.ExecuteNonQuery();
        }

        public long GetSessionIdByAccessKey(string accessKey)
        {
            var SQL = "SELECT Id FROM Sessions WHERE AccessKey = @accessKey";

            using var sqlConn = GetSqlConnection();
            using var sqlCmd = GetSqlCommand(SQL, sqlConn);

            sqlCmd.Parameters.Add("accessKey", SqlDbType.NVarChar).Value = accessKey;
            sqlConn.Open();

            long id = Convert.ToInt64(sqlCmd.ExecuteScalar());

            sqlConn.Close();

            return id;
        }

        public List<Session> GetAllSessionsFromSupervisor(long id)
        {
            var SQL = "SELECT * FROM Sessions WHERE SupervisorId = @id";

            using var sqlConn = GetSqlConnection();
            using var sqlCmd = GetSqlCommand(SQL, sqlConn);

            sqlCmd.Parameters.Add("id", SqlDbType.BigInt).Value = id;
            sqlConn.Open();

            using var reader = sqlCmd.ExecuteReader();
            var sessions = new List<Session>();
            while (reader.Read())
            {
                sessions.Add(new Session
                {
                    Id = Convert.ToInt64(reader["Id"].ToString()),
                    StartTime = reader["StartTime"].ToString(),
                    EndTime = reader["EndTime"].ToString(),
                    SupervisorId = Convert.ToInt64(reader["SupervisorId"].ToString()),
                    QuestionnaireId = Convert.ToInt64(reader["QuestionnaireId"].ToString()),
                    AccessKey = reader["AccessKey"].ToString()
                });
                
            }

            return sessions;
        }
    }
}
