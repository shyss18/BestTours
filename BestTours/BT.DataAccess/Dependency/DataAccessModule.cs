using BT.DataAccess.Interfaces;
using BT.DataAccess.Repositories;
using Ninject.Modules;

namespace BT.DataAccess.Dependency
{
    public class DataAccessModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IUnitOfWork>().To<UnitOfWork>().WithConstructorArgument("connectionString", "IdentityDb");
            Bind<ITourRepository>().To<TourRepository>();
            Bind<IHotelRepository>().To<HotelRepository>();
        }
    }
}
