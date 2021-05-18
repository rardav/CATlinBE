using CATlinBE.BusinessLogicLayer;
using CATlinBE.DataAccessLayer.EntityDALs;
using CATlinBE.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CATlinBE.WebApi.Controllers.EntitiesControllers
{ 
    public class QuestionnairesController : BaseAPIController
    {
        // GET: api/<QuestionnairesController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Questionnaire>>> GetQuestionnaires()
        {
            return await Task.FromResult(new QuestionnaireBLL
            {
                QuestionnaireDAL = new QuestionnaireDAL()
            }.GetAllQuestionnaires());
        }
    }
}
