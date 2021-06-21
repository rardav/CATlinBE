using CATlinBE.BusinessLogicLayer;
using CATlinBE.DataAccessLayer.EntityDALs;
using CATlinBE.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CATlinBE.WebApi.Controllers
{
    public class ImagesController : BaseAPIController
    {
        [Route("~/api/images/id/{id}")]
        [HttpGet("{id}")]
        public async Task<ActionResult<Image>> GetImageById(long id)
        {
            return await Task.FromResult(new ImageBLL
            {
                ImageDAL = new ImageDAL()
            }.GetImageById(id));
        }

        [Route("~/api/images/url/{url}/id")]
        [HttpGet("{url}")]
        public async Task<ActionResult<long>> GetIdByUrl(string url)
        {
            return await Task.FromResult(new ImageBLL
            {
                ImageDAL = new ImageDAL()
            }.GetIdByUrl(url));
        }

        [HttpPost]
        public async Task<ActionResult> InsertImage(Image image)
        {
            await Task.Run(() => new ImageBLL
            {
                ImageDAL = new ImageDAL()
            }.InsertImage(image));

            return Ok();
        }
    }
}
