using CATlinBE.DataAccessLayer.Interfaces;
using CATlinBE.Entities;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;

namespace CATlinBE.DataAccessLayer.EntityDALs
{
    public class QuestionnaireDAL : BaseDAL, IQuestionnaireDAL
    {
        public List<Questionnaire> GetAllQuestionnaires()
        {
            var questionnaires = new List<Questionnaire>();
            var SQL = "SELECT * FROM Questionnaires";

            using var sqlConn = GetSqlConnection();
            using var sqlCmd = GetSqlCommand(SQL, sqlConn);

            sqlConn.Open();

            using var reader = sqlCmd.ExecuteReader();

            while (reader.Read())
            {
                var questionnaire = new Questionnaire
                {
                    Id = Convert.ToInt64(reader["Id"].ToString()),
                    Title = reader["Title"].ToString(),
                    Description = reader["Description"].ToString(),
                    ShortDescription = reader["ShortDescription"].ToString(),
                    Subject = reader["Subject"].ToString(),
                    URLTitle = reader["URLTitle"].ToString(),
                    ImageId = reader.IsDBNull("ImageId")? 0 : Convert.ToInt64(reader["ImageId"].ToString()),


                };
                questionnaires.Add(questionnaire);
            }

            return questionnaires;
        }

        public Questionnaire GetQuestionnaireById(long id)
        {
            var SQL = "SELECT * FROM Questionnaires WHERE Id = @id";

            using var sqlConn = GetSqlConnection();
            using var sqlCmd = GetSqlCommand(SQL, sqlConn);

            sqlCmd.Parameters.Add("id", SqlDbType.BigInt).Value = id;
            sqlConn.Open();

            using var reader = sqlCmd.ExecuteReader();
            var questionnaire = new Questionnaire();
            while (reader.Read())
            {
                questionnaire.Id = Convert.ToInt64(reader["Id"].ToString());
                questionnaire.Title = reader["Title"].ToString();
                questionnaire.Description = reader["Description"].ToString();
                questionnaire.ShortDescription = reader["ShortDescription"].ToString();
                questionnaire.Subject = reader["Subject"].ToString();
                questionnaire.URLTitle = reader["URLTitle"].ToString();
                questionnaire.ImageId = reader.IsDBNull("ImageId") ? 0 : Convert.ToInt64(reader["ImageId"].ToString());
            }

            return questionnaire;
        }

        public Questionnaire GetQuestionnaireByURLTitle(string title)
        {
            var SQL = "SELECT * FROM Questionnaires WHERE urltitle = @title";

            using var sqlConn = GetSqlConnection();
            using var sqlCmd = GetSqlCommand(SQL, sqlConn);

            sqlCmd.Parameters.Add("title", SqlDbType.VarChar).Value = title;
            sqlConn.Open();

            using var reader = sqlCmd.ExecuteReader();
            var questionnaire = new Questionnaire();
            while (reader.Read())
            {
                questionnaire.Id = Convert.ToInt64(reader["Id"].ToString());
                questionnaire.Title = reader["Title"].ToString();
                questionnaire.Description = reader["Description"].ToString();
                questionnaire.ShortDescription = reader["ShortDescription"].ToString();
                questionnaire.Subject = reader["Subject"].ToString();
                questionnaire.URLTitle = reader["URLTitle"].ToString();
                questionnaire.ImageId = reader.IsDBNull("ImageId") ? 0 : Convert.ToInt64(reader["ImageId"].ToString());
            }

            return questionnaire;
        }

        public long GetQuestionnaireIdByURLTitle(string title)
        {
            var SQL = "SELECT Id FROM Questionnaires WHERE UrlTitle = @title";

            using var sqlConn = GetSqlConnection();
            using var sqlCmd = GetSqlCommand(SQL, sqlConn);

            sqlCmd.Parameters.Add("title", SqlDbType.NVarChar).Value = title;
            sqlConn.Open();

            long id = Convert.ToInt64(sqlCmd.ExecuteScalar());

            sqlConn.Close();

            return id;
        }
    }
}
