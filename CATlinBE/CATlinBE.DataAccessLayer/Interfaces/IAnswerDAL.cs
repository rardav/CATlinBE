using CATlinBE.Entities;
using System.Collections.Generic;

namespace CATlinBE.DataAccessLayer.Interfaces
{
    public interface IAnswerDAL
    {
        List<Answer> GetAllAnswersFromQuestion(long questionId);
        List<Answer> GetAllAnswers();
        void InsertJSON(List<Answer> answers);
        void InsertAnswer(Answer answer);
        void UpdateAnswer(Answer answer);
        void DeleteAnswer(long questionId);
    }
}
