using BT.DataAccess.Context;
using BT.DataAccess.Interfaces;
using BT.Dom.Entities;

namespace BT.DataAccess.Repositories
{
    public class ClientManager : IClientManager
    {
        public UserContext Database { get; set; }
        public ClientManager(UserContext db)
        {
            Database = db;
        }

        public void Create(ClientProfile item)
        {
            Database.ClientProfiles.Add(item);
            Database.SaveChanges();
        }

        public void Dispose()
        {
            Database.Dispose();
        }
    }
}