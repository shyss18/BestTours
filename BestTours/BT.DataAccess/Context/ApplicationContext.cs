using System.Data.Entity;
using BT.Dom.Entities;
using Microsoft.AspNet.Identity.EntityFramework;

namespace BT.DataAccess.Context
{
    public class ApplicationContext : IdentityDbContext<User>
    {
        public ApplicationContext(string connectionString) : base(connectionString)
        { }

        public DbSet<Tour> Tours { get; set; }
        public DbSet<Hotel> Hotels { get; set; }
        public DbSet<ClientProfile> ClientProfiles { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>().ToTable("Users");
            modelBuilder.Entity<IdentityRole>().ToTable("Roles");
            modelBuilder.Entity<IdentityUserRole>().ToTable("UserRoles");
            modelBuilder.Entity<IdentityUserClaim>().ToTable("UserClaims");
            modelBuilder.Entity<IdentityUserLogin>().ToTable("UserLogins");

            modelBuilder.Entity<User>()
                .HasMany(u => u.Tours)
                .WithMany(t => t.Users)
                .Map(m =>
                {
                    m.ToTable("Orders");
                    m.MapLeftKey("UserId");
                    m.MapRightKey("TourId");
                });
        }
    }
}
