using CATlinBE.Entities;
using System.Collections.Generic;

namespace CATlinBE.DataAccessLayer.Interfaces
{
    public interface IQuestionDAL
    {
        List<Question> GetAllQuestionsFromQuestionnaire(long questionnaireId);
    }
}
