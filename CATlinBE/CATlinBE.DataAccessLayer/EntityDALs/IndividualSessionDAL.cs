using CATlinBE.DataAccessLayer.Interfaces;
using CATlinBE.Entities;
using System;
using System.Collections.Generic;
using System.Data;

namespace CATlinBE.DataAccessLayer.EntityDALs
{
    public class IndividualSessionDAL : BaseDAL, IIndividualSessionDAL
    {
        public void InsertIndividualSession(IndividualSession individualSession)
        {
            var SQL = "INSERT INTO IndividualSessions " +
                "(Ability, StartTime, EndTime, ExamineeId, SessionId) " +
                "VALUES (@Ability, @StartTime, @EndTime, @ExamineeId, @SessionId)";

            using var sqlConn = GetSqlConnection();
            using var sqlCmd = GetSqlCommand(SQL, sqlConn);

            sqlConn.Open();

            sqlCmd.Parameters.Add("@Ability", SqlDbType.Float).Value = individualSession.Ability;
            sqlCmd.Parameters.Add("@StartTime", SqlDbType.DateTime).Value = DateTime.Parse(individualSession.StartTime);
            sqlCmd.Parameters.Add("@EndTime", SqlDbType.DateTime).Value = DateTime.Parse(individualSession.EndTime);
            sqlCmd.Parameters.Add("@ExamineeId", SqlDbType.BigInt).Value = individualSession.ExamineeId;
            sqlCmd.Parameters.Add("@SessionId", SqlDbType.BigInt).Value = individualSession.SessionId;

            sqlCmd.ExecuteNonQuery();

            sqlConn.Close();
        }

        public void UpdateIndividualSession(IndividualSession individualSession)
        {
            var SQL = "UPDATE IndividualSessions " +
                "SET Ability=@ability, StartTime=@startTime, EndTime=@endTime, ExamineeId=@examineeId, SessionId=@sessionId " +
                "WHERE Id = @id";

            using var sqlConn = GetSqlConnection();
            using var sqlCmd = GetSqlCommand(SQL, sqlConn);

            sqlConn.Open();

            sqlCmd.Parameters.Add("@id", SqlDbType.BigInt).Value = individualSession.Id;
            sqlCmd.Parameters.Add("@ability", SqlDbType.Float).Value = individualSession.Ability;
            sqlCmd.Parameters.Add("@startTime", SqlDbType.DateTime).Value = individualSession.StartTime;
            sqlCmd.Parameters.Add("@endTime", SqlDbType.DateTime).Value = individualSession.EndTime;
            sqlCmd.Parameters.Add("@examineeId", SqlDbType.BigInt).Value = individualSession.ExamineeId;
            sqlCmd.Parameters.Add("@sessionId", SqlDbType.BigInt).Value = individualSession.SessionId;

            sqlCmd.ExecuteNonQuery();

            sqlConn.Close();
        }

        public List<IndividualSession> GetAllIndividualSessionsFromUser(long id)
        {
            var sessions = new List<IndividualSession>();
            var SQL = "SELECT * FROM IndividualSessions WHERE examineeId = @Id";

            using var sqlConn = GetSqlConnection();
            using var sqlCmd = GetSqlCommand(SQL, sqlConn);

            sqlCmd.Parameters.Add("Id", SqlDbType.BigInt).Value = id;
            sqlConn.Open();

            using var reader = sqlCmd.ExecuteReader();

            while (reader.Read())
            {
                var session = new IndividualSession
                {
                    Id = Convert.ToInt64(reader["Id"].ToString()),
                    Ability = (float)Convert.ToDouble(reader["Ability"].ToString()),
                    StartTime = reader["StartTime"].ToString(),
                    EndTime = reader["EndTime"].ToString(),
                    ExamineeId = Convert.ToInt64(reader["ExamineeId"].ToString()),
                    SessionId = Convert.ToInt64(reader["SessionId"].ToString())
                };
                sessions.Add(session);
            }

            return sessions;
        }

        public long GetIdOfIndividualSession(long sessionId, long userId)
        {
            var SQL = "SELECT Id FROM IndividualSessions WHERE examineeId = @userId AND sessionId = @sessionId";

            using var sqlConn = GetSqlConnection();
            using var sqlCmd = GetSqlCommand(SQL, sqlConn);

            sqlCmd.Parameters.Add("userId", SqlDbType.BigInt).Value = userId;
            sqlCmd.Parameters.Add("sessionId", SqlDbType.BigInt).Value = sessionId;
            sqlConn.Open();

            long id = Convert.ToInt64(sqlCmd.ExecuteScalar());

            sqlConn.Close();

            return id;
        }

        public List<IndividualSession> GetAllIndividualSessionsFromSession(long sessionId)
        {
            var sessions = new List<IndividualSession>();
            var SQL = "SELECT * FROM IndividualSessions WHERE SessionId = @Id";

            using var sqlConn = GetSqlConnection();
            using var sqlCmd = GetSqlCommand(SQL, sqlConn);

            sqlCmd.Parameters.Add("Id", SqlDbType.BigInt).Value = sessionId;
            sqlConn.Open();

            using var reader = sqlCmd.ExecuteReader();

            while (reader.Read())
            {
                var session = new IndividualSession
                {
                    Id = Convert.ToInt64(reader["Id"].ToString()),
                    Ability = (float)Convert.ToDouble(reader["Ability"].ToString()),
                    StartTime = reader["StartTime"].ToString(),
                    EndTime = reader["EndTime"].ToString(),
                    ExamineeId = Convert.ToInt64(reader["ExamineeId"].ToString()),
                    SessionId = Convert.ToInt64(reader["SessionId"].ToString())
                };
                sessions.Add(session);
            }

            return sessions;
        }
    }
}
