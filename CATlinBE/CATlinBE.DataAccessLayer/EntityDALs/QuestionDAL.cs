using CATlinBE.DataAccessLayer.Interfaces;
using CATlinBE.Entities;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
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
                    UniqueKey = reader["UniqueKey"].ToString(),
                    ImageId = reader["ImageId"] != DBNull.Value ? Convert.ToInt64(reader["ImageId"].ToString()) : 0,
                    QuestionnaireId = Convert.ToInt32(reader["QuestionnaireId"].ToString()),
                    TimeToAnswer = Convert.ToInt32(reader["TimeToAnswer"].ToString()),
                    Difficulty = (float)Convert.ToDouble(reader["Difficulty"].ToString()),
                    AdministratorId = reader["AdministratorId"] != DBNull.Value ? Convert.ToInt64(reader["AdministratorId"].ToString()) : 0
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

        public void InsertQuestion(Question question)
        {
            string SQL;
            if(question.ImageId == 0)
            {
                SQL = "INSERT INTO questions(text, questionnaireId, timeToAnswer, difficulty, administratorId, uniqueKey) " +
                    "VALUES (@text, @questionnaireId, @timeToAnswer, @difficulty, @administratorId, @uniqueKey)";
            } 
            else
            {
                SQL = "INSERT INTO questions(text, questionnaireId, timeToAnswer, difficulty, imageId, administratorId, uniqueKey) " +
                    "VALUES (@text, @questionnaireId, @timeToAnswer, @difficulty, @imageId, @administratorId, @uniqueKey)";
            }
            

            using var sqlConn = GetSqlConnection();
            using var sqlCmd = GetSqlCommand(SQL, sqlConn);

            sqlCmd.Parameters.Add("text", SqlDbType.NVarChar, -1).Value = question.Text;
            sqlCmd.Parameters.Add("uniqueKey", SqlDbType.NVarChar, -1).Value = question.UniqueKey;
            sqlCmd.Parameters.Add("questionnaireId", SqlDbType.BigInt).Value = question.QuestionnaireId;
            sqlCmd.Parameters.Add("timeToAnswer", SqlDbType.Int).Value = question.TimeToAnswer;
            sqlCmd.Parameters.Add("difficulty", SqlDbType.Float).Value = question.Difficulty;
            sqlCmd.Parameters.Add("administratorId", SqlDbType.Float).Value = question.AdministratorId;
            if (question.ImageId != 0) sqlCmd.Parameters.Add("imageId", SqlDbType.BigInt).Value = question.ImageId;

            sqlConn.Open();
            sqlCmd.ExecuteNonQuery();
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
                question.ImageId = reader["ImageId"] != DBNull.Value ? Convert.ToInt64(reader["ImageId"].ToString()) : 0l;
                question.UniqueKey = reader["UniqueKey"].ToString();
                question.QuestionnaireId = Convert.ToInt32(reader["QuestionnaireId"].ToString());
                question.TimeToAnswer = Convert.ToInt32(reader["TimeToAnswer"].ToString());
                question.Difficulty = (float)Convert.ToDouble(reader["Difficulty"].ToString());
                question.AdministratorId = Convert.ToInt64(reader["AdministratorId"].ToString());
            }

            return question;
        }

        public List<Question> GetQuestionsFromAdministrator(long administratorId, long questionnaireId)
        {
            var SQL = "SELECT * FROM Questions WHERE AdministratorId = @administratorId AND QuestionnaireId = @questionnaireId";

            using var sqlConn = GetSqlConnection();
            using var sqlCmd = GetSqlCommand(SQL, sqlConn);

            sqlCmd.Parameters.Add("administratorId", SqlDbType.BigInt).Value = administratorId;
            sqlCmd.Parameters.Add("questionnaireId", SqlDbType.BigInt).Value = questionnaireId;
            sqlConn.Open();

            using var reader = sqlCmd.ExecuteReader();
            var questions = new List<Question>();
            while (reader.Read())
            {
                var question = new Question
                {
                    Id = Convert.ToInt64(reader["Id"].ToString()),
                    Text = reader["Text"].ToString(),
                    ImageId = reader["ImageId"] != DBNull.Value ? Convert.ToInt64(reader["ImageId"].ToString()) : 0,
                    UniqueKey = reader["UniqueKey"].ToString(),
                    QuestionnaireId = Convert.ToInt32(reader["QuestionnaireId"].ToString()),
                    TimeToAnswer = Convert.ToInt32(reader["TimeToAnswer"].ToString()),
                    Difficulty = (float)Convert.ToDouble(reader["Difficulty"].ToString()),
                    AdministratorId = Convert.ToInt64(reader["AdministratorId"].ToString())
                };
                questions.Add(question);
            }

            return questions;
        }

        public Question GetQuestion(long id)
        {
            var SQL = "SELECT * FROM Questions WHERE Id = @id";

            using var sqlConn = GetSqlConnection();
            using var sqlCmd = GetSqlCommand(SQL, sqlConn);

            sqlCmd.Parameters.Add("Id", SqlDbType.BigInt).Value = id;
            sqlConn.Open();

            using var reader = sqlCmd.ExecuteReader();
            var question = new Question();
            while (reader.Read())
            {
                question = new Question
                {
                    Id = Convert.ToInt64(reader["Id"].ToString()),
                    Text = reader["Text"].ToString(),
                    ImageId = reader["ImageId"] != DBNull.Value ? Convert.ToInt64(reader["ImageId"].ToString()) : 0,
                    UniqueKey = reader["UniqueKey"].ToString(),
                    QuestionnaireId = Convert.ToInt32(reader["QuestionnaireId"].ToString()),
                    TimeToAnswer = Convert.ToInt32(reader["TimeToAnswer"].ToString()),
                    Difficulty = (float)Convert.ToDouble(reader["Difficulty"].ToString()),
                    AdministratorId = Convert.ToInt64(reader["AdministratorId"].ToString())
                };
            }

            return question;
        }

        public Question GetQuestionByKey(string key)
        {
            var SQL = "SELECT * FROM Questions WHERE UniqueKey = @uniqueKey";

            using var sqlConn = GetSqlConnection();
            using var sqlCmd = GetSqlCommand(SQL, sqlConn);

            sqlCmd.Parameters.Add("uniqueKey", SqlDbType.NVarChar).Value = key;
            sqlConn.Open();

            using var reader = sqlCmd.ExecuteReader();
            var question = new Question();
            while (reader.Read())
            {
                question = new Question
                {
                    Id = Convert.ToInt64(reader["Id"].ToString()),
                    Text = reader["Text"].ToString(),
                    Image = reader["Image"] != DBNull.Value ? reader["Image"].ToString().ToCharArray().Select(x => (byte)x).ToArray() : null,
                    UniqueKey = reader["UniqueKey"].ToString(),
                    QuestionnaireId = Convert.ToInt32(reader["QuestionnaireId"].ToString()),
                    TimeToAnswer = Convert.ToInt32(reader["TimeToAnswer"].ToString()),
                    Difficulty = (float)Convert.ToDouble(reader["Difficulty"].ToString()),
                    AdministratorId = Convert.ToInt64(reader["AdministratorId"].ToString())
                };
            }

            return question;
        }

        public void UpdateQuestion(Question question)
        {
            var SQL = "UPDATE Questions " +
                "SET Text=@text, TimeToAnswer=@timeToAnswer, Difficulty=@difficulty " +
                "WHERE Id = @id";

            using var sqlConn = GetSqlConnection();
            using var sqlCmd = GetSqlCommand(SQL, sqlConn);

            sqlConn.Open();

            sqlCmd.Parameters.Add("@id", SqlDbType.BigInt).Value = question.Id;
            sqlCmd.Parameters.Add("@difficulty", SqlDbType.Float).Value = question.Difficulty;
            sqlCmd.Parameters.Add("@timeToAnswer", SqlDbType.Int).Value = question.TimeToAnswer;
            sqlCmd.Parameters.Add("@text", SqlDbType.NVarChar).Value = question.Text;

            sqlCmd.ExecuteNonQuery();

            sqlConn.Close();
        }

        public void DeleteQuestion(long id)
        {
            Debug.WriteLine(id);
            var SQL = "DELETE FROM Questions " +
                "WHERE Id = @id";

            using var sqlConn = GetSqlConnection();
            using var sqlCmd = GetSqlCommand(SQL, sqlConn);

            sqlConn.Open();

            sqlCmd.Parameters.Add("@id", SqlDbType.BigInt).Value = id;

            sqlCmd.ExecuteNonQuery();

            sqlConn.Close();
        }

        public List<string> GetAllUniqueKeys()
        {
            var SQL = "SELECT UniqueKey FROM Questions";

            using var sqlConn = GetSqlConnection();
            using var sqlCmd = GetSqlCommand(SQL, sqlConn);

            sqlConn.Open();

            using var reader = sqlCmd.ExecuteReader();
            var keys = new List<string>();
            while (reader.Read())
            {
                keys.Add(reader["UniqueKey"].ToString());
            }

            return keys;
        }
    }
}
