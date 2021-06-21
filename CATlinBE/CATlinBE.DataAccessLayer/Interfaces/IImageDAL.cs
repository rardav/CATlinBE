using CATlinBE.Entities;

namespace CATlinBE.DataAccessLayer.Interfaces
{
    public interface IImageDAL
    {
        Image GetImageById(long id);
        void InsertImage(Image image);
        long GetIdByUrl(string url);
    }
}
