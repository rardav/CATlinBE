using CATlinBE.Entities;

namespace CATlinBE.DataAccessLayer.Interfaces
{
    public interface ISessionDAL
    {
        public void InsertSession(Session session);
        public Session GetSessionById(long id);
    }
}
