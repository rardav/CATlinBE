using CATlinBE.BusinessLogicLayer;
using CATlinBE.DataAccessLayer.EntityDALs;
using CATlinBE.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CATlinBE.WebApi.Controllers.EntitiesControllers
{ 
    public class QuestionnairesController : BaseAPIController
    {
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Questionnaire>>> GetQuestionnaires()
        {
            return await Task.FromResult(new QuestionnaireBLL
            {
                QuestionnaireDAL = new QuestionnaireDAL()
            }.GetAllQuestionnaires());
        }

        [Route("~/api/questionnaires/title/{title}")]
        [HttpGet("{title}")]
        public async Task<ActionResult<Questionnaire>> GetQuestionnaire(string title)
        {
            return await Task.FromResult(new QuestionnaireBLL
            {
                QuestionnaireDAL = new QuestionnaireDAL()
            }.GetQuestionnaireByURLTitle(title));
        }

        [Route("~/api/questionnaires/{title}/id")]
        [HttpGet("{title}")]
        public async Task<ActionResult<long>> GetQuestionnaireIdByUrlTitle(string title)
        {
            return await Task.FromResult(new QuestionnaireBLL
            {
                QuestionnaireDAL = new QuestionnaireDAL()
            }.GetQuestionnaireIdByURLTitle(title));
        }

        [Route("~/api/questionnaires/id/{id}")]
        [HttpGet("{id}")]
        public async Task<ActionResult<Questionnaire>> GetQuestionnaireById(long id)
        {
            return await Task.FromResult(new QuestionnaireBLL
            {
                QuestionnaireDAL = new QuestionnaireDAL()
            }.GetQuestionnaireById(id));
        }


    }
}
