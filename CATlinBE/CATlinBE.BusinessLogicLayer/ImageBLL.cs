using CATlinBE.DataAccessLayer.Interfaces;
using CATlinBE.Entities;


namespace CATlinBE.BusinessLogicLayer
{
    public class ImageBLL
    {
        public IImageDAL ImageDAL { get; set; }

        public Image GetImageById(long imageId)
        {
            return ImageDAL.GetImageById(imageId);
        }

        public long GetIdByUrl(string url)
        {
            return ImageDAL.GetIdByUrl(url);
        }

        public void InsertImage(Image image)
        {
            ImageDAL.InsertImage(image);
        }
    }
}
