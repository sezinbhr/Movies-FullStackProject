using Movies.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Movies.DataAccess.Repositories
{
    public class FakeUserRepository : IUserRepository
    {
        public User Add(User entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }


        private List<User> users = new List<User>()
        {
                new User {Email = "smellycat@gmail.com", Password="12345", userRole="User", userName="Phoebe"},
                new User   {Email = "bananahammock@gmail.com", Password="123456", userRole = "Admin", userName="Ursula"},
                new User   {Email = "reginaphalange@gmail.com", Password="9876", userRole="Editor", userName="Regina"},
        };
        public IList<User> GetAll()
        {
            return users;
        }

        public User GetById(int id)
        {
            throw new NotImplementedException();
        }

        public IList<User> GetWithCriteria(Func<User, bool> criteria)
        {
            return users.Where(criteria).ToList();
        }

        public User Update(User entity)
        {
            throw new NotImplementedException();
        }
    }
}
