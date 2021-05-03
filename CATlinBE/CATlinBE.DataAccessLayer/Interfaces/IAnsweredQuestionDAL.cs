using CATlinBE.Entities;
using System.Collections.Generic;

namespace CATlinBE.DataAccessLayer.Interfaces
{
    public interface IAnsweredQuestionDAL
    {
        List<AnsweredQuestion> GetAllAnsweredQuestionsFromIndividualSession(long individualSessionId);
        void InsertAnsweredQuestion(AnsweredQuestion answeredQuestion);
    }
}
