using CATlinBE.BusinessLogicLayer;
using CATlinBE.DataAccessLayer.EntityDALs;
using CATlinBE.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;

namespace CATlinBE.WebApi.Controllers
{
    public class BuggyController: BaseAPIController
    {
        [Authorize]
        [HttpGet("auth")]
        public ActionResult<string> GetSecret()
        {
            //return "secret text";
            return Unauthorized();
        }
        [HttpGet("not-found")]
        public ActionResult<User> GetNotFound()
        {
            var thing = new UserBLL
            {
                UserDAL = new UserDAL()
            }.GetUserById(-1);

            if (thing.Id == 0) return NotFound();
            return Ok(thing);
        }

        [HttpGet("server-error")]
        public ActionResult<string> GetServerError()
        {
            var thing = new UserBLL
            {
                UserDAL = new UserDAL()
            }.GetUserById(-1);

            if (thing.Id == 0) thing = null;

            var thingToReturn = thing.ToString();
            return thingToReturn;
        }

        [HttpGet("bad-request")]
        public ActionResult<string> GetBadRequest()
        {
            return BadRequest("This was not a good request");
        }
    }
}
