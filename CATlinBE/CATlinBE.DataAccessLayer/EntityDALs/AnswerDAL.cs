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
        public List<Answer> GetAllAnswers()
        {
            var answers = new List<Answer>();
            var SQL = "SELECT * FROM Answers";

            using var sqlConn = GetSqlConnection();
            using var sqlCmd = GetSqlCommand(SQL, sqlConn);

            sqlConn.Open();

            using var reader = sqlCmd.ExecuteReader();

            while (reader.Read())
            {
                var answer = new Answer
                {
                    Id = Convert.ToInt64(reader["Id"].ToString()),
                    Text = reader["Text"].ToString(),
                    QuestionId = Convert.ToInt64(reader["QuestionId"].ToString()),
                    IsCorrect = Convert.ToInt64(reader["IsCorrect"].ToString())
                };
                answers.Add(answer);
            }

            return answers;
        }

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
                    IsCorrect = Convert.ToInt64(reader["IsCorrect"].ToString())
                };
                answers.Add(answer);
            }

            return answers;
        }

        //to delete
        public void InsertJSON(List<Answer> answers)
        {
            foreach (Answer answer in answers)
            {
                var SQL = "INSERT INTO answers(text, questionId, isCorrect) VALUES (@text, @questionId, @isCorrect)";

                using var sqlConn = GetSqlConnection();
                using var sqlCmd = GetSqlCommand(SQL, sqlConn);

                sqlCmd.Parameters.Add("text", SqlDbType.NVarChar, -1).Value = answer.Text;
                sqlCmd.Parameters.Add("questionId", SqlDbType.BigInt).Value = answer.QuestionId;
                sqlCmd.Parameters.Add("isCorrect", SqlDbType.Int).Value = answer.IsCorrect;
                sqlConn.Open();

                sqlCmd.ExecuteNonQuery();
                sqlConn.Close();
            }

        }
    }
}
