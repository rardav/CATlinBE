using CATlinBE.DataAccessLayer.Interfaces;
using CATlinBE.Entities;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;

namespace CATlinBE.DataAccessLayer.EntityDALs
{
    public class AnsweredQuestionDAL : BaseDAL, IAnsweredQuestionDAL
    {
        public List<AnsweredQuestion> GetAllAnsweredQuestionsFromIndividualSession(long individualSessionId)
        {
            var answeredQuestions = new List<AnsweredQuestion>();
            var SQL = "SELECT * FROM AnsweredQuestions WHERE IndividualSessionId = @Id";

            using var sqlConn = GetSqlConnection();
            using var sqlCmd = GetSqlCommand(SQL, sqlConn);

            sqlCmd.Parameters.Add("Id", SqlDbType.BigInt).Value = individualSessionId;
            sqlConn.Open();

            using var reader = sqlCmd.ExecuteReader();

            while (reader.Read())
            {
                var question = new AnsweredQuestion
                {
                    Id = Convert.ToInt64(reader["Id"].ToString()),
                    IndividualSessionId = Convert.ToInt64(reader["IndividualSessionId"].ToString()),
                    QuestionDifficulty = (float)Convert.ToDouble(reader["QuestionDifficulty"].ToString()),
                    AnsweredCorrectly = Convert.ToInt32(reader["AnsweredCorrectly"]),
                    NumberOfOrder = Convert.ToInt32(reader["NumberOfOrder"].ToString())

                };
                answeredQuestions.Add(question);
            }

            return answeredQuestions;
        }

        public void InsertAnsweredQuestion(AnsweredQuestion answeredQuestion)
        {
            var SQL = "INSERT INTO AnsweredQuestions (IndividualSessionId, QuestionDifficulty, AnsweredCorrectly, NumberOfOrder) VALUES (@IndividualSessionId, @QuestionDifficulty, @AnsweredCorrectly, @NumberOfOrder)";

            using var sqlConn = GetSqlConnection();
            using var sqlCmd = GetSqlCommand(SQL, sqlConn);

            sqlConn.Open();

            sqlCmd.Parameters.Add("@IndividualSessionId", SqlDbType.BigInt).Value = answeredQuestion.IndividualSessionId;
            sqlCmd.Parameters.Add("@QuestionDifficulty", SqlDbType.Float).Value = answeredQuestion.QuestionDifficulty;
            sqlCmd.Parameters.Add("@AnsweredCorrectly", SqlDbType.Int).Value = answeredQuestion.AnsweredCorrectly;
            sqlCmd.Parameters.Add("@NumberOfOrder", SqlDbType.Int).Value = answeredQuestion.NumberOfOrder;

            sqlCmd.ExecuteNonQuery();
        }
    }
}
