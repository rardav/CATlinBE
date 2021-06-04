using CATlinBE.DataAccessLayer.Interfaces;
using CATlinBE.Entities;
using System.Collections.Generic;

namespace CATlinBE.BusinessLogicLayer
{
    public class IndividualSessionBLL
    {
        public IIndividualSessionDAL IndividualSessionDAL { get; set; }


        public void InsertIndividualSession(IndividualSession individualSession)
        {
            IndividualSessionDAL.InsertIndividualSession(individualSession);
        }

        public void UpdateIndividualSession(IndividualSession individualSession)
        {
            IndividualSessionDAL.UpdateIndividualSession(individualSession);
        }

        public List<IndividualSession> GetAllIndividualSessionsFromUser(long userId)
        {
            return IndividualSessionDAL.GetAllIndividualSessionsFromUser(userId);
        }

        public long GetIdOfIndividualSession(long sessionId, long userId)
        {
            return IndividualSessionDAL.GetIdOfIndividualSession(sessionId, userId);
        }


    }
}
