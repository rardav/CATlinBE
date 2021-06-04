using CATlinBE.BusinessLogicLayer;
using CATlinBE.DataAccessLayer.EntityDALs;
using CATlinBE.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CATlinBE.WebApi.Controllers.EntitiesControllers
{
    public class IndividualSessionsController: BaseAPIController
    {
        [Route("~/api/users/{id}/individualsessions")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<IndividualSession>>> GetIndividualSessionsFromUser(long id)
        {
            return await Task.FromResult(new IndividualSessionBLL
            {
                IndividualSessionDAL = new IndividualSessionDAL()
            }.GetAllIndividualSessionsFromUser(id));
        }

        [Route("~/api/sessions/{sessionId}/users/{userId}/individualsessions/id")]
        [HttpGet]
        public async Task<ActionResult<long>> GetIdOfIndividualSession(long sessionId, long userId)
        {
            return await Task.FromResult(new IndividualSessionBLL
            {
                IndividualSessionDAL = new IndividualSessionDAL()
            }.GetIdOfIndividualSession(sessionId, userId));
        }

        [HttpPost]
        public async Task<ActionResult> InsertIndividualSession(IndividualSession individualSession)
        {
            await Task.Run(() => new IndividualSessionBLL
            {
                IndividualSessionDAL = new IndividualSessionDAL()
            }.InsertIndividualSession(individualSession));

            return Ok();
        }

        [HttpPut]
        public async Task<ActionResult> UpdateIndividualSession(IndividualSession individualSession)
        {
            await Task.Run(() => new IndividualSessionBLL
            {
                IndividualSessionDAL = new IndividualSessionDAL()
            }.UpdateIndividualSession(individualSession));

            return Ok();
        }


    }
}
