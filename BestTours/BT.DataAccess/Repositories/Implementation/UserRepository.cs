using System;
using System.Collections.Generic;
using System.Linq;
using BT.DataAccess.Context;
using BT.Dom.Entities;

namespace BT.DataAccess.Repositories.Implementation
{
    public class UserRepository : IUserRepository
    {
        private ApplicationContext _db;

        public UserRepository()
        {
            _db = new ApplicationContext();
        }

        public User GetById(int? id)
        {
            var user = _db.Users.Where(model => model.Id == id).Select(m => m).FirstOrDefault();

            return user;
        }

        public ICollection<User> FindBy(Func<User, bool> predicate)
        {
            var users = _db.Users.Where(predicate).Select(m => m).ToList();

            return users;
        }

        public void CreateUser(User item)
        {
            _db.Users.Add(item);
        }

        public void UpdateUser(User item)
        {
            throw new NotImplementedException();
        }

        public void DeleteUser(int id)
        {
            var user = _db.Users.Where(m => m.Id == id).Select(m => m).FirstOrDefault();

            if (user != null)
            {
                _db.Users.Remove(user);
                _db.SaveChanges();
            }
        }
    }
}