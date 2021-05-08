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
    }
}
