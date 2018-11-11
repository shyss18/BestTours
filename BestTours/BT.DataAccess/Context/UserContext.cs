using System.Data.Entity;
using BT.Dom.Entities;
using Microsoft.AspNet.Identity.EntityFramework;

namespace BT.DataAccess.Context
{
    public class UserContext : IdentityDbContext<User>
    {
        public UserContext(string connectionString) : base(connectionString)
        { }

        public DbSet<ClientProfile> ClientProfiles { get; set; }
    }
}
