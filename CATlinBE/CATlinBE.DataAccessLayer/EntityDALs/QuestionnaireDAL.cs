using CATlinBE.DataAccessLayer.Interfaces;
using CATlinBE.Entities;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;

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
                    Title = reader["Title"].ToString()
                };
                questionnaires.Add(questionnaire);
            }

            return questionnaires;
        }
    }
}
