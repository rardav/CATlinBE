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
    }
}
