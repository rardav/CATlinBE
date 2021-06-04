using CATlinBE.DataAccessLayer.Interfaces;
using CATlinBE.Entities;
using System.Collections.Generic;

namespace CATlinBE.BusinessLogicLayer
{
    public class UserBLL
    {
        public IUserDAL UserDAL { get; set; }

        public void InsertUser(User user)
        {
            UserDAL.InsertUser(user);
        }

        public void RegisterUser(User user)
        {
            UserDAL.RegisterUser(user);
        }

        public List<User> GetAllUsers()
        {
            return UserDAL.GetAllUsers();
        }

        public bool UserExists(string email)
        {
            return UserDAL.UserExists(email);
        }

        public User GetUserByEmail(string email)
        {
            return UserDAL.GetUserByEmail(email);
        }

        public User GetUserById(long id)
        {
            return UserDAL.GetUserById(id);
        }

        public long GetUserIdByEmail(string email)
        {
            return UserDAL.GetIdFromEmail(email);
        }
    }
}
