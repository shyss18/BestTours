using Microsoft.AspNet.Identity;
using BT.Dom.Entities;

namespace BT.DataAccess.Identity
{
    public class RoleManager : RoleManager<Role>
    {
        public RoleManager(IRoleStore<Role, string> store) : base(store)
        {
        }
    }
}
