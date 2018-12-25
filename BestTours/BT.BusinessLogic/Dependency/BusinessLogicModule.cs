using BT.BusinessLogic.Interface;
using BT.BusinessLogic.Services;
using Ninject.Modules;

namespace BT.BusinessLogic.Dependency
{
    public class BusinessLogicModule : NinjectModule
    {
        public override void Load()
        {
            Bind<ITourService>().To<TourService>();
            Bind<IUserService>().To<UserService>();
            Bind<IHotelService>().To<HotelService>();
        }
    }
}
