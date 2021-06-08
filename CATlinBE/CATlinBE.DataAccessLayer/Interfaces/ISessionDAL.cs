using CATlinBE.Entities;
using System.Collections.Generic;

namespace CATlinBE.DataAccessLayer.Interfaces
{
    public interface ISessionDAL
    {
        public void InsertSession(Session session);
        public Session GetSessionById(long id);
        public long GetSessionIdByAccessKey(string accessKey);
        public Session GetSessionByAccessKey(string accessKey);
        public List<string> GetAllAccessKeys();
        public List<Session> GetAllSessionsFromSupervisor(long id);
    }
}
