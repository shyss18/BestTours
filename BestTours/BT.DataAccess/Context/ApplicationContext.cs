using System.Data.Entity;
using BT.Dom.Entities;
using Microsoft.AspNet.Identity.EntityFramework;

namespace BT.DataAccess.Context
{
    public class ApplicationContext : IdentityDbContext<User>
    {
        public ApplicationContext(string connectionString) : base(connectionString)
        { }

        public DbSet<ClientProfile> ClientProfiles { get; set; }
    }
}
