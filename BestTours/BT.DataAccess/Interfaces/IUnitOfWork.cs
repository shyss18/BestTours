using System;
using System.Threading.Tasks;
using BT.DataAccess.Identity;

namespace BT.DataAccess.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        UserManager UserManager { get; }
        IClientManager ClientManager { get; }
        RoleManager RoleManager { get; }
        ITourRepository TourRepository { get; }
        Task SaveAsync();
    }
}
