using CATlinBE.DataAccessLayer.Interfaces;
using CATlinBE.Entities;
using System.Collections.Generic;

namespace CATlinBE.BusinessLogicLayer
{
    public class QuestionnaireBLL
    {
        public IQuestionnaireDAL QuestionnaireDAL { get; set; }
        
        public List<Questionnaire> GetAllQuestionnaires()
        {
            return QuestionnaireDAL.GetAllQuestionnaires();
        }

        public Questionnaire GetQuestionnaireByURLTitle(string title)
        {
            return QuestionnaireDAL.GetQuestionnaireByURLTitle(title);
        }

        public Questionnaire GetQuestionnaireById(long id)
        {
            return QuestionnaireDAL.GetQuestionnaireById(id);
        }

        public long GetQuestionnaireIdByURLTitle(string title)
        {
            return QuestionnaireDAL.GetQuestionnaireIdByURLTitle(title);
        }
    }
}
