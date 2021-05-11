using CATlinBE.DataAccessLayer.Interfaces;
using CATlinBE.Entities;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;

namespace CATlinBE.DataAccessLayer.EntityDALs
{
    public class AnswerDAL : BaseDAL, IAnswerDAL
    {

        public List<Answer> GetAllAnswersFromQuestion(long questionId)
        {
            var answers = new List<Answer>();
            var SQL = "SELECT * FROM Answers WHERE QuestionId = @Id";

            using var sqlConn = GetSqlConnection();
            using var sqlCmd = GetSqlCommand(SQL, sqlConn);

            sqlCmd.Parameters.Add("Id", SqlDbType.BigInt).Value = questionId;
            sqlConn.Open();

            using var reader = sqlCmd.ExecuteReader();

            while (reader.Read())
            {
                var answer = new Answer
                {
                    Id = Convert.ToInt64(reader["Id"].ToString()),
                    Text = reader["Text"].ToString(),
                    QuestionId = Convert.ToInt64(reader["QuestionId"].ToString()),
                    IsCorrect = (bool)reader["IsCorrect"]
                };
                answers.Add(answer);
            }

            return answers;
        }
    }
}
