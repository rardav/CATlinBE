using CATlinBE.BusinessLogicLayer;
using CATlinBE.DataAccessLayer.EntityDALs;
using CATlinBE.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CATlinBE.WebApi.Controllers
{
    public class ImagesController : BaseAPIController
    {
        [HttpGet("{id}")]
        public async Task<ActionResult<Image>> GetIndividualSessionsFromUser(long id)
        {
            return await Task.FromResult(new ImageBLL
            {
                ImageDAL = new ImageDAL()
            }.GetImageById(id));
        }
    }
}
