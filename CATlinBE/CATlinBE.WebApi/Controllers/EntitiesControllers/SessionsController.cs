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
        [HttpGet("{id}")]
        public async Task<ActionResult<Session>> GetSession(long id)
        {
            return await Task.FromResult(new SessionBLL
            {
                SessionDAL = new SessionDAL()
            }.GetSessionById(id));
        }
    }
}
