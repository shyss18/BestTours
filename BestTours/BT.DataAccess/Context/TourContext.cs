using System.Data.Entity;
using BT.Dom.Entities;

namespace BT.DataAccess.Context
{
    public class TourContext : DbContext
    {
        public TourContext(string connectionString) : base(connectionString)
        { }

        public DbSet<Tour> Tours { get; set; }
    }
}
