using CATlinBE.BusinessLogicLayer;
using CATlinBE.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Web.Http;
using HttpGetAttribute = System.Web.Http.HttpGetAttribute;
using RouteAttribute = System.Web.Http.RouteAttribute;

namespace CATlinBE.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class QuestionnaireController: ControllerBase
    {
        private readonly QuestionnaireBLL BLL;

        public QuestionnaireController(QuestionnaireBLL bLL)
        {
            BLL = bLL;
        }

        [HttpGet]
        public ActionResult<List<Questionnaire>> Get()
        {
            return BLL.GetAllQuestionnaires();
        }
    }
}
