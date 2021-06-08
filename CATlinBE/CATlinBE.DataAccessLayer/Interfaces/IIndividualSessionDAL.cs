using CATlinBE.Entities;
using System.Collections.Generic;

namespace CATlinBE.DataAccessLayer.Interfaces
{
    public interface IIndividualSessionDAL
    {
        void InsertIndividualSession(IndividualSession individualSession);
        void UpdateIndividualSession(IndividualSession individualSession);
        List<IndividualSession> GetAllIndividualSessionsFromUser(long userId);
        long GetIdOfIndividualSession(long sessionId, long userId);
        List<IndividualSession> GetAllIndividualSessionsFromSession(long sessionId);
    }
}
