using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BT.Dom.Entities;

namespace BT.DataAccess.Repositories
{
    interface IUserRepository
    {
        User GetById(int? id);

        ICollection<User> FindBy(Func<User, bool> predicate);

        void CreateUser(User item);

        void UpdateUser(User item);

        void DeleteUser(int id);
    }
}
