using CATlinBE.DataAccessLayer.Interfaces;
using CATlinBE.Entities;

namespace CATlinBE.BusinessLogicLayer
{
    public class SessionBLL
    {
        public ISessionDAL SessionDAL { get; set; }

        public void InsertSession(Session session)
        {
            SessionDAL.InsertSession(session);
        }

        public Session GetSessionById (long id)
        {
            return SessionDAL.GetSessionById(id);
        }
    }
}
