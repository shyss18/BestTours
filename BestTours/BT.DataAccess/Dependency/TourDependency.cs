using BT.DataAccess.Interfaces;
using BT.DataAccess.Repositories;
using Ninject.Modules;

namespace BT.DataAccess.Dependency
{
    public class RepositoryModule : NinjectModule
    {
        public override void Load()
        {
            Bind<ITourRepository>().To<TourRepository>();
        }
    }
}
