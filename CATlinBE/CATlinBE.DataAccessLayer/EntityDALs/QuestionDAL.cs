using CATlinBE.DataAccessLayer.Interfaces;
using CATlinBE.Entities;
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
    }
}
