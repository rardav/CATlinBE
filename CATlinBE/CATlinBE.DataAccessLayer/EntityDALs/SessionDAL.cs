using CATlinBE.DataAccessLayer.Interfaces;
using CATlinBE.Entities;
using System.Data;

namespace CATlinBE.DataAccessLayer.EntityDALs
{
    public class SessionDAL : BaseDAL, ISessionDAL
    {
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
