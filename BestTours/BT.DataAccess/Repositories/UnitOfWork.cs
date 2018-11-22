using System;
using System.Threading.Tasks;
using BT.DataAccess.Context;
using BT.DataAccess.Identity;
using BT.DataAccess.Interfaces;
using BT.Dom.Entities;
using Microsoft.AspNet.Identity.EntityFramework;

namespace BT.DataAccess.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        public UserManager UserManager { get; }
        public RoleManager RoleManager { get; }
        public IClientManager ClientManager { get; }
        public ITourRepository TourRepository { get; }
        public IHotelRepository HotelRepository { get; }

        private readonly ApplicationContext _db;
        private bool _disposed = false;

        public UnitOfWork(string connectionString)
        {
            _db = new ApplicationContext(connectionString);
            UserManager = new UserManager(new UserStore<User>(_db));
            RoleManager = new RoleManager(new RoleStore<Role>(_db));
            ClientManager = new ClientManager(_db);
            TourRepository = new TourRepository(_db);
            HotelRepository = new HotelRepository(_db);
        }

        public async Task SaveAsync()
        {
            await _db.SaveChangesAsync();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    UserManager.Dispose();
                    RoleManager.Dispose();
                    ClientManager.Dispose();
                    TourRepository.Dispose();
                }

                _disposed = true;
            }
        }
    }
}
