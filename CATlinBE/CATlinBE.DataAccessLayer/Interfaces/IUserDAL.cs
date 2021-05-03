using CATlinBE.Entities;
using System.Collections.Generic;

namespace CATlinBE.DataAccessLayer.Interfaces
{
    public interface IUserDAL
    {
        List<User> GetAllUsers();
        void InsertUser(User user);
    }
}
