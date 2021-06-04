using CATlinBE.DataAccessLayer.Interfaces;
using CATlinBE.Entities;
using System.Collections.Generic;

namespace CATlinBE.BusinessLogicLayer
{
    public class AnswerBLL
    {
        public IAnswerDAL AnswerDAL { get; set; }

        public List<Answer> GetAllAnswersFromQuestion(long questionId)
        {
            return AnswerDAL.GetAllAnswersFromQuestion(questionId);
        }

        public List<Answer> GetAllAnswers()
        {
            return AnswerDAL.GetAllAnswers();
        }

        public void InsertJSON(List<Answer> answers)
        {
            AnswerDAL.InsertJSON(answers);
        }
    }
}
