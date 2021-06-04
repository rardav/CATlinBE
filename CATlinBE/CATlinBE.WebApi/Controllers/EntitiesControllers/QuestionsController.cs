using CATlinBE.BusinessLogicLayer;
using CATlinBE.DataAccessLayer.EntityDALs;
using CATlinBE.Entities;
using CATlinBE.WebApi.DTOs;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CATlinBE.WebApi.Controllers
{
    public class QuestionsController : BaseAPIController
    {
        [Route("~/api/questionnaires/{id}/questions")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<QuestionDTO>>> GetQuestions(long id)
        {
            var questions = await Task.Run(() => new QuestionBLL
            {
                QuestionDAL = new QuestionDAL()
            }.GetAllQuestionsFromQuestionnaire(id));

            var questionsDTO = new List<QuestionDTO>();
            foreach(Question q in questions) {
                questionsDTO.Add(new QuestionDTO
                {
                    Id = q.Id,
                    Text = q.Text,
                    TimeToAnswer = q.TimeToAnswer,
                    Difficulty = q.Difficulty
                });
            }

            return questionsDTO;
        }


        [HttpPost]
        public void InsertJson(List<Question> question)
        {
            new QuestionBLL
            {
                QuestionDAL = new QuestionDAL()
            }.InsertJSON(question);
        }
    }
}
