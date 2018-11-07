using System;
using BT.Dom.Entities;

namespace BT.DataAccess.Interfaces
{
    public interface IClientManager : IDisposable
    {
        void Create(ClientProfile profile);
    }
}
