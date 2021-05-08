using CATlinBE.DataAccessLayer.Interfaces;
using CATlinBE.Entities;

namespace CATlinBE.BusinessLogicLayer
{
    public class UserBLL
    {
        public IUserDAL UserDAL { get; set; }

        public void InsertUser(User user)
        {
            UserDAL.InsertUser(user);
        }

    }
}
