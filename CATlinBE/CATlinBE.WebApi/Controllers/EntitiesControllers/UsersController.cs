using CATlinBE.BusinessLogicLayer;
using CATlinBE.DataAccessLayer.EntityDALs;
using CATlinBE.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CATlinBE.WebApi.Controllers.EntitiesControllers
{
    public class UsersController: BaseAPIController
    {
        [HttpGet]
        [AllowAnonymous]
        public async Task<ActionResult<IEnumerable<User>>> GetUsers()
        {
            return await Task.FromResult(new UserBLL
            {
                UserDAL = new UserDAL()
            }.GetAllUsers());
        }

        [Authorize]
        [Route("~/api/users/email/{email}")]
        [HttpGet]
        public async Task<ActionResult<User>> GetUser(string email)
        {
            return await Task.FromResult(new UserBLL
            {
                UserDAL = new UserDAL()
            }.GetUserByEmail(email));
        }

        [Authorize]
        [Route("~/api/users/id/{id}")]
        [HttpGet]
        public async Task<ActionResult<User>> GetUserById(long id)
        {
            return await Task.FromResult(new UserBLL
            {
                UserDAL = new UserDAL()
            }.GetUserById(id));
        }

        [Route("~/api/users/{email}/properties/id")]
        [HttpGet]
        public async Task<ActionResult<long>> GetId(string email)
        {
            return await Task.FromResult(new UserBLL
            {
                UserDAL = new UserDAL()
            }.GetUserIdByEmail(email));
        }
    }
}
