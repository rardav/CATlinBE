using CATlinBE.BusinessLogicLayer;
using CATlinBE.DataAccessLayer.EntityDALs;
using CATlinBE.Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CATlinBE.WebApi.Controllers.EntitiesControllers
{
    public class AnsweredQuestionsController : BaseAPIController
    {
        [Route("~/api/individualsessions/{id}/answeredquestions")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AnsweredQuestion>>> GetQuestionnaires(long id)
        {
            return await Task.FromResult(new AnsweredQuestionBLL
            {
                AnsweredQuestionDAL = new AnsweredQuestionDAL()
            }.GetAllAnsweredQuestionsFromIndividualSession(id));

        }

        [HttpPost]
        public async Task<ActionResult> InsertAnsweredQuestion(AnsweredQuestion answeredQuestion)
        {
            await Task.Run(() => new AnsweredQuestionBLL
            {
                AnsweredQuestionDAL = new AnsweredQuestionDAL()
            }.InsertAnsweredQuestion(answeredQuestion));

            return Ok();
        }
    }
}
