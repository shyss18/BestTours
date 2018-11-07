using BT.BusinessLogic.Interface;
using BT.DataAccess.Repositories;

namespace BT.BusinessLogic.Services
{
    public class ServiceCreator : IServiceCreator
    {
        public IUserService CreateUserService(string connection)
        {
            return new UserService(new UnitOfWork(connection));
        }
    }
}
