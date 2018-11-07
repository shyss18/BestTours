using BT.DataAccess.Context;
using BT.DataAccess.Interfaces;
using BT.Dom.Entities;

namespace BT.DataAccess.Repositories
{
    public class ClientManager : IClientManager
    {
        public ApplicationContext DataBase { get; set; }

        public ClientManager(ApplicationContext db)
        {
            DataBase = db;
        }

        public void Create(ClientProfile profile)
        {
            DataBase.ClientProfiles.Add(profile);
            DataBase.SaveChanges();
        }

        public void Dispose()
        {
            DataBase.Dispose();
        }
    }
}
