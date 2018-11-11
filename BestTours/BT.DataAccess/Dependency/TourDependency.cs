using BT.DataAccess.Interfaces;
using BT.DataAccess.Repositories;
using Ninject.Modules;

namespace BT.DataAccess.Dependency
{
    public class TourDependency : NinjectModule
    {
        public override void Load()
        {
            Bind<ITourRepository>().To<TourRepository>();
        }
    }
}
