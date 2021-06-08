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
    public class SessionsController: BaseAPIController
    {
        [Route("~/api/sessions/id/{id}")]
        [HttpGet]
        public async Task<ActionResult<Session>> GetSession(long id)
        {
            return await Task.FromResult(new SessionBLL
            {
                SessionDAL = new SessionDAL()
            }.GetSessionById(id));
        }

        [Route("~/api/sessions/accesskey/{accesskey}")]
        [HttpGet]
        public async Task<ActionResult<Session>> GetSession(string accesskey)
        {
            return await Task.FromResult(new SessionBLL
            {
                SessionDAL = new SessionDAL()
            }.GetSessionByAccessKey(accesskey));
        }

        [Route("~/api/sessions/accesskeys")]
        [HttpGet]
        public async Task<ActionResult<List<string>>> GetAccessKeys()
        {
            return await Task.FromResult(new SessionBLL
            {
                SessionDAL = new SessionDAL()
            }.GetAllAccessKeys());
        }

        [Route("~/api/users/{id}/sessions")]
        [HttpGet]
        public async Task<ActionResult<List<Session>>> GetSessions(long id)
        {
            return await Task.FromResult(new SessionBLL
            {
                SessionDAL = new SessionDAL()
            }.GetAllSessionsFromSupervisor(id));
        }

        [Route("~/api/sessions/accesskey/{accesskey}/properties/id")]
        [HttpGet]
        public async Task<ActionResult<long>> GetIdByAccessKey(string accessKey)
        {
            return await Task.FromResult(new SessionBLL
            {
                SessionDAL = new SessionDAL()
            }.GetSessionIdByAccessKey(accessKey));
        }


        [HttpPost]
        public async Task<ActionResult> InsertSession(Session session)
        {
            await Task.Run(() => new SessionBLL
            {
                SessionDAL = new SessionDAL()
            }.InsertSession(session));

            return Ok();
        }
    }
}
