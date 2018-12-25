using System.Data.Entity;

namespace BT.DataAccess.Context
{
    class DBInitialize : CreateDatabaseIfNotExists<ApplicationContext>
    {
        protected override void Seed(ApplicationContext context)
        {
            context.Database.ExecuteSqlCommand("ALTER TABLE Tours ADD CONSTRAINT Hotels_Tours FOREIGN KEY (HotelId) REFERENCES Hotels (Id) ON DELETE SET NULL");
            context.SaveChanges();
        }
    }
}
