using CATlinBE.BusinessLogicLayer;
using CATlinBE.DataAccessLayer.EntityDALs;
using CATlinBE.Entities;
using CATlinBE.WebApi.DTOs;
using CATlinBE.WebApi.Interfaces;
using Microsoft.AspNetCore.Http;
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
        private readonly IPhotoService _photoService;

        public QuestionsController(IPhotoService photoService)
        {
            _photoService = photoService;
        }

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

        [HttpGet("id", Name = "GetQuestion")]
        public async Task<ActionResult<Question>> GetQuestion(long id)
        {
            return await Task.Run(() => new QuestionBLL
            {
                QuestionDAL = new QuestionDAL()
            }.GetQuestion(id));
        }

        [Route("~/api/questions/key/{key}")]
        [HttpGet("key")]
        public async Task<ActionResult<Question>> GetQuestionByKey(string key)
        {
            return await Task.Run(() => new QuestionBLL
            {
                QuestionDAL = new QuestionDAL()
            }.GetQuestionByKey(key));
        }

        //[HttpPost]
        //public void InsertJson(List<Question> question)
        //{
        //    new QuestionBLL
        //    {
        //        QuestionDAL = new QuestionDAL()
        //    }.InsertJSON(question);
        //}

        [HttpPost]
        public async Task<ActionResult> Insert(Question question)
        {
            await Task.Run(() => new QuestionBLL
            {
                QuestionDAL = new QuestionDAL()
            }.InsertQuestion(question));

            return Ok();
        }

        [Route("~/api/users/{administratorId}/questionnaires/{questionnaireId}/questions")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Question>>> GetQuestionsFromAdministrator(long administratorId, long questionnaireId)
        {
            return await Task.Run(() => new QuestionBLL
            {
                QuestionDAL = new QuestionDAL()
            }.GetQuestionsFromAdministrator(administratorId, questionnaireId));

        }

        [Route("~/api/questions/keys")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<string>>> GetUniqueKeys()
        {
            return await Task.Run(() => new QuestionBLL
            {
                QuestionDAL = new QuestionDAL()
            }.GetUniqueKeys());
        }

        [HttpPut]
        public async Task<ActionResult> UpdateQuestion(Question question)
        {
            await Task.Run(() => new QuestionBLL
            {
                QuestionDAL = new QuestionDAL()
            }.UpdateQuestion(question));

            return Ok();
        }


        [HttpPost("add-photo")]
        public async Task<ActionResult<Image>> AddImage(IFormFile file)
        {
            var result = await _photoService.AddPhotoAsync(file);

            if (result.Error != null) return BadRequest(result.Error.Message);
            
            var image = new Image
            {
                Url = result.SecureUrl.AbsoluteUri,
                PublicId = result.PublicId
            };

            return CreatedAtRoute("GetQuestion", new { id = image.Id }, image);
                

            return BadRequest("Problem adding photo");
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteQuestion(long id)
        {
            await Task.Run(() => new QuestionBLL
            {
                QuestionDAL = new QuestionDAL()
            }.DeleteQuestion(id));

            return Ok();
        }
    }
}
