using CATlinBE.DataAccessLayer.Interfaces;
using CATlinBE.Entities;
using System.Collections.Generic;

namespace CATlinBE.BusinessLogicLayer
{
    public class QuestionBLL
    {
        public IQuestionDAL QuestionDAL { get; set; }

        public List<Question> GetAllQuestionsFromQuestionnaire(long questionnaireId)
        {
            return QuestionDAL.GetAllQuestionsFromQuestionnaire(questionnaireId);
        }

        public void InsertJSON(List<Question> question)
        {
            QuestionDAL.InsertJSON(question);
        }

        public void InsertQuestion(Question question)
        {
            QuestionDAL.InsertQuestion(question);
        }

        public List<Question> GetQuestionsFromAdministrator(long administratorId, long questionnaireId)
        {
            return QuestionDAL.GetQuestionsFromAdministrator(administratorId, questionnaireId);
        }

        public List<string> GetUniqueKeys()
        {
            return QuestionDAL.GetAllUniqueKeys();
        }

        public void UpdateQuestion(Question question)
        {
            QuestionDAL.UpdateQuestion(question);
        }

        public void DeleteQuestion(long id)
        {
            QuestionDAL.DeleteQuestion(id);
        }

        public Question GetQuestion(long id)
        {
            return QuestionDAL.GetQuestion(id);
        }

        public Question GetQuestionByKey(string key)
        {
            return QuestionDAL.GetQuestionByKey(key);
        }



    }
}
