using CATlinBE.DataAccessLayer.Interfaces;
using CATlinBE.Entities;
using System.Collections.Generic;

namespace CATlinBE.BusinessLogicLayer
{
    public class InstitutionBLL
    {
        public IInstitutionDAL InstitutionDAL { get; set; }

        public List<Institution> GetAllInstitutions()
        {
            return InstitutionDAL.GetAllInstitutions();
        }
    }
}
