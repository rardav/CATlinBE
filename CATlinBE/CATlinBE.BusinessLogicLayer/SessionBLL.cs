using CATlinBE.DataAccessLayer.Interfaces;
using CATlinBE.Entities;
using System.Collections.Generic;

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

        public Session GetSessionByAccessKey(string accessKey)
        {
            return SessionDAL.GetSessionByAccessKey(accessKey);
        }

        public List<string> GetAllAccessKeys()
        {
            return SessionDAL.GetAllAccessKeys();
        }

        public List<Session> GetAllSessionsFromSupervisor(long id)
        {
            return SessionDAL.GetAllSessionsFromSupervisor(id);
        }

        public long GetSessionIdByAccessKey(string accessKey)
        {
            return SessionDAL.GetSessionIdByAccessKey(accessKey);
        }
    }
}
