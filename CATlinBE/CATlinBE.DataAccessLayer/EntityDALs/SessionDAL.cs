using CATlinBE.DataAccessLayer.Interfaces;
using CATlinBE.Entities;
using Microsoft.Extensions.Configuration;
using System;
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
                session.StartTime = Convert.ToDateTime(reader["StartTime"].ToString());
                session.EndTime = Convert.ToDateTime(reader["EndTime"].ToString());
                session.SupervisorId = Convert.ToInt64(reader["SupervisorId"].ToString());
                session.QuestionnaireId = Convert.ToInt64(reader["QuestionnaireId"].ToString());
            }

            return session;
        }

        public void InsertSession(Session session)
        {
            var SQL = "INSERT INTO Sessions (StartTime, EndTime, SupervisorId, QuestionnaireId) VALUES (@StartTime, @EndTime, @SupervisorId, @QuestionnaireId)";

            using var sqlConn = GetSqlConnection();
            using var sqlCmd = GetSqlCommand(SQL, sqlConn);

            sqlConn.Open();

            sqlCmd.Parameters.Add("@StartTime", SqlDbType.DateTime).Value = session.StartTime;
            sqlCmd.Parameters.Add("@EndTime", SqlDbType.DateTime).Value = session.EndTime;
            sqlCmd.Parameters.Add("@SupervisorId", SqlDbType.BigInt).Value = session.SupervisorId;
            sqlCmd.Parameters.Add("@QuestionnaireId", SqlDbType.BigInt).Value = session.QuestionnaireId;

            sqlCmd.ExecuteNonQuery();
        }
    }
}
