using CATlinBE.BusinessLogicLayer;
using CATlinBE.DataAccessLayer.EntityDALs;
using CATlinBE.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CATlinBE.WebApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class QuestionnairesController : ControllerBase
    {
        // GET: api/<QuestionnairesController>
        [HttpGet]
        public IEnumerable<Questionnaire> Get()
        {
            return new QuestionnaireBLL
            {
                QuestionnaireDAL = new QuestionnaireDAL()
            }.GetAllQuestionnaires();
        }

        // GET api/<QuestionnairesController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<QuestionnairesController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<QuestionnairesController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<QuestionnairesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
