using CATlinBE.Entities;
using System.Collections.Generic;

namespace CATlinBE.DataAccessLayer.Interfaces
{
    public interface IUserDAL
    {
        List<User> GetAllUsers();
        void InsertUser(User user);
        void RegisterUser(User user);
        bool UserExists(string email);
        User GetUserByEmail(string email);
        User GetUserById(long id);
    }
}
