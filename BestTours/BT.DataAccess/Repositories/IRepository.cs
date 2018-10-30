using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BT.DataAccess.Repositories
{
    interface IRepository<T> where T: class
    {
        T GetById(int id);

        IReadOnlyCollection<T> FindBy(Func<T, bool> predicate);

        void Create(T item);

        void Update(T item);

        void Delete(int id);
    }
}
