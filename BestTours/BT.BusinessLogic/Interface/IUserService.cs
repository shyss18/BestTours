using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using BT.BusinessLogic.DTO;
using BT.BusinessLogic.Infrastructure;

namespace BT.BusinessLogic.Interface
{
    public interface IUserService : IDisposable
    {
        Task<OperationDetails> Create(UserDTO userDto);
        Task<ClaimsIdentity> Authenticate(UserDTO userDto);
        Task SetInitialData(UserDTO adminDto, List<string> roles);
    }
}
