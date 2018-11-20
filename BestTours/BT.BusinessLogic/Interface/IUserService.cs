using System;
using System.Security.Claims;
using System.Threading.Tasks;
using BT.BusinessLogic.DTO;
using BT.BusinessLogic.Infrastructure;
using BT.Dom.Entities;

namespace BT.BusinessLogic.Interface
{
    public interface IUserService : IDisposable
    {
        Task<OperationDetails> Create(UserDTO userDto);
        Task<ClaimsIdentity> Authenticate(UserDTO userDto);
        Task SetInitialDataAsync();
        User GetById(string id);
        void UpdateUser(User user);
    }
}
