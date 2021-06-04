using CATlinBE.DataAccessLayer.Interfaces;
using CATlinBE.Entities;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace CATlinBE.DataAccessLayer.EntityDALs
{
    public class QuestionDAL : BaseDAL, IQuestionDAL
    {
        public List<Question> GetAllQuestionsFromQuestionnaire(long questionnaireId)
        {
            var questions = new List<Question>();
            var SQL = "SELECT * FROM Questions WHERE QuestionnaireId = @Id";

            using var sqlConn = GetSqlConnection();
            using var sqlCmd = GetSqlCommand(SQL, sqlConn);

            sqlCmd.Parameters.Add("Id", SqlDbType.BigInt).Value = questionnaireId;
            sqlConn.Open();

            using var reader = sqlCmd.ExecuteReader();

            while (reader.Read())
            {
                var question = new Question
                {
                    Id = Convert.ToInt64(reader["Id"].ToString()),
                    Text = reader["Text"].ToString(),
                    Image = reader["Image"] != DBNull.Value ? reader["Image"].ToString().ToCharArray().Select(x => (byte)x).ToArray() : null,
                    QuestionnaireId = Convert.ToInt32(reader["QuestionnaireId"].ToString()),
                    TimeToAnswer = Convert.ToInt32(reader["TimeToAnswer"].ToString()),
                    Difficulty = (float)Convert.ToDouble(reader["Difficulty"].ToString())
                };
                questions.Add(question);
            }

            return questions;
        }

        //to delete
        public void InsertJSON(List<Question> question)
        {
            foreach(Question q in question)
            {
                var SQL = "INSERT INTO questions(text, questionnaireId, timeToAnswer, difficulty) VALUES (@text, @questionnaireId, @timeToAnswer, @difficulty)";

                using var sqlConn = GetSqlConnection();
                using var sqlCmd = GetSqlCommand(SQL, sqlConn);

                sqlCmd.Parameters.Add("text", SqlDbType.NVarChar, -1).Value = q.Text;
                sqlCmd.Parameters.Add("questionnaireId", SqlDbType.BigInt).Value = q.QuestionnaireId;
                sqlCmd.Parameters.Add("timeToAnswer", SqlDbType.Int).Value = q.TimeToAnswer;
                sqlCmd.Parameters.Add("difficulty", SqlDbType.Float).Value = q.Difficulty;
                sqlConn.Open();

                sqlCmd.ExecuteNonQuery();
                sqlConn.Close();
            }
            
        }

        public Question GetQuestionFromQuestionnaireByDifficulty(long questionnaireId, float difficulty)
        {
            var SQL = "SELECT * FROM Questions WHERE questionnaireId = @questionnaireId AND difficulty = @difficulty" ;

            using var sqlConn = GetSqlConnection();
            using var sqlCmd = GetSqlCommand(SQL, sqlConn);

            sqlCmd.Parameters.Add("questionnaireId", SqlDbType.VarChar).Value = questionnaireId;
            sqlConn.Open();

            using var reader = sqlCmd.ExecuteReader();
            var question = new Question();
            while (reader.Read())
            {
                question.Id = Convert.ToInt64(reader["Id"].ToString());
                question.Text = reader["Text"].ToString();
                question.Image = reader["Image"] != DBNull.Value ? reader["Image"].ToString().ToCharArray().Select(x => (byte)x).ToArray() : null;
                question.QuestionnaireId = Convert.ToInt32(reader["QuestionnaireId"].ToString());
                question.TimeToAnswer = Convert.ToInt32(reader["TimeToAnswer"].ToString());
                question.Difficulty = (float)Convert.ToDouble(reader["Difficulty"].ToString());
            }

            return question;
        }
    }
}
