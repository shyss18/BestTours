using BT.Dom.Entities;
using Microsoft.AspNet.Identity;

namespace BT.DataAccess.Identity
{
    public class UserManager : UserManager<User>
    {
        public UserManager(IUserStore<User> store) : base(store)
        { }
    }
}
