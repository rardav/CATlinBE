using CATlinBE.Entities;
using System.Collections.Generic;

namespace CATlinBE.DataAccessLayer.Interfaces
{
    public interface IInstitutionDAL
    {
        public List<Institution> GetAllInstitutions();
        public void InsertInstitution(string institutionName);
    }
}
