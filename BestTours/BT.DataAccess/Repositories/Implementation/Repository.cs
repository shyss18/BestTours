using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BT.DataAccess.Context;

namespace BT.DataAccess.Repositories.Implementation
{
    public class UserRepository<T> : IRepository<T> where T: class
    {
        private ApplicationContext _db;

        public UserRepository()
        {
            _db = new ApplicationContext();
        }

        public T GetById(int id)
        {
            throw new NotImplementedException();
        }

        public IReadOnlyCollection<T> FindBy(Func<T, bool> predicate)
        {
            throw new NotImplementedException();
        }

        public void Create(T item)
        {
            throw new NotImplementedException();
        }

        public void Update(T item)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}
