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
        [HttpGet("{email}")]
        public async Task<ActionResult<User>> GetUser(string email)
        {
            return await Task.FromResult(new UserBLL
            {
                UserDAL = new UserDAL()
            }.GetUserByEmail(email));
        }
    }
}
