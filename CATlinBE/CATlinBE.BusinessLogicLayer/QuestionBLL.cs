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
    }
}
