using CATlinBE.DataAccessLayer.Interfaces;
using CATlinBE.Entities;
using System.Collections.Generic;

namespace CATlinBE.BusinessLogicLayer
{
    public class AnsweredQuestionBLL
    {
        public IAnsweredQuestionDAL AnsweredQuestionDAL { get; set; }

        public void InsertAnsweredQuestion(AnsweredQuestion answeredQuestion)
        {
            AnsweredQuestionDAL.InsertAnsweredQuestion(answeredQuestion);
        }

        public List<AnsweredQuestion> GetAllAnsweredQuestionsFromIndividualSession(long individualSessionId)
        {
            return AnsweredQuestionDAL.GetAllAnsweredQuestionsFromIndividualSession(individualSessionId);
        }
    }
}
