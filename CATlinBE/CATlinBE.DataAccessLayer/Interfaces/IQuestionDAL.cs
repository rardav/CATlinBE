using CATlinBE.Entities;
using System.Collections.Generic;

namespace CATlinBE.DataAccessLayer.Interfaces
{
    public interface IQuestionDAL
    {
        List<Question> GetAllQuestionsFromQuestionnaire(long questionnaireId);
        void InsertJSON(List<Question> question);
        List<Question> GetQuestionsFromAdministrator(long administratorId, long questionnaireId);
        void UpdateQuestion(Question question);
        void DeleteQuestion(long id);
        void InsertQuestion(Question question);
        Question GetQuestion(long id);
        Question GetQuestionByKey(string key);
        List<string> GetAllUniqueKeys();
    }
}
