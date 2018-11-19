using BT.BusinessLogic.Interface;
using BT.BusinessLogic.Services;
using Ninject.Modules;

namespace BT.BusinessLogic.Dependency
{
    public class UserServiceModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IUserService>().To<UserService>();
        }
    }
}
