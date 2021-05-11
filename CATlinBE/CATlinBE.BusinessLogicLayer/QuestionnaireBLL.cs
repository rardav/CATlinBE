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
    }
}
