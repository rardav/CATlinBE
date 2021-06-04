using CATlinBE.BusinessLogicLayer;
using CATlinBE.DataAccessLayer.EntityDALs;
using CATlinBE.Entities;
using CATlinBE.WebApi.DTOs;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CATlinBE.WebApi.Controllers.EntitiesControllers
{
    public class AnswersController : BaseAPIController
    {
        [Route("~/api/questions/{id}/answers")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AnswerDTO>>> GetAnswers(long id)
        {
            var answers = await Task.Run(() => new AnswerBLL
            {
                AnswerDAL = new AnswerDAL()
            }.GetAllAnswersFromQuestion(id));

            var answersDTO = new List<AnswerDTO>();
            foreach (Answer a in answers)
            {
                answersDTO.Add(new AnswerDTO
                {
                    Id = a.Id,
                    Text = a.Text,
                    QuestionId = a.QuestionId,
                    IsCorrect = a.IsCorrect == 1

                });
            }

            return answersDTO;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<AnswerDTO>>> GetAnswers()
        {
            var answers = await Task.Run(() => new AnswerBLL
            {
                AnswerDAL = new AnswerDAL()
            }.GetAllAnswers());

            var answersDTO = new List<AnswerDTO>();
            foreach (Answer a in answers)
            {
                answersDTO.Add(new AnswerDTO
                {
                    Id = a.Id,
                    Text = a.Text,
                    QuestionId = a.QuestionId,
                    IsCorrect = a.IsCorrect == 1

                });
            }

            return answersDTO;
        }

        [HttpPost]
        public void InsertJson(List<Answer> answers)
        {
            new AnswerBLL
            {
                AnswerDAL = new AnswerDAL()
            }.InsertJSON(answers);
        }
    }
}
