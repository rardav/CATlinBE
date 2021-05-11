using CATlinBE.DataAccessLayer.Interfaces;
using CATlinBE.Entities;
using Microsoft.Extensions.Configuration;
using System.Data;

namespace CATlinBE.DataAccessLayer.EntityDALs
{
    public class IndividualSessionDAL : BaseDAL, IIndividualSessionDAL
    {
        public void InsertIndividualSession(IndividualSession individualSession)
        {
            var SQL = "INSERT INTO IndividualSessions (Ability, StartTime, EndTime, ExamineeId, SessionId) VALUES (@Ability, @StartTime, @EndTime, @ExamineeId, @SessionId)";

            using var sqlConn = GetSqlConnection();
            using var sqlCmd = GetSqlCommand(SQL, sqlConn);

            sqlConn.Open();

            sqlCmd.Parameters.Add("@Ability", SqlDbType.Float).Value = individualSession.Ability;
            sqlCmd.Parameters.Add("@StartTime", SqlDbType.DateTime).Value = individualSession.StartTime;
            sqlCmd.Parameters.Add("@EndTime", SqlDbType.DateTime).Value = individualSession.EndTime;
            sqlCmd.Parameters.Add("@ExamineeId", SqlDbType.BigInt).Value = individualSession.ExamineeId;
            sqlCmd.Parameters.Add("@SessionId", SqlDbType.BigInt).Value = individualSession.SessionId;

            sqlCmd.ExecuteNonQuery();
        }
    }
}
