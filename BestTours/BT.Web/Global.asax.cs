using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Optimization;
using BT.BusinessLogic.Dependency;
using BT.DataAccess.Dependency;
using BT.Web.App_Start;
using Ninject.Modules;
using Ninject;
using Ninject.Web.Mvc;

namespace BT.Web
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            NinjectModule serviceModule = new ServiceModule();
            NinjectModule repositoryModule = new RepositoryModule();
            IKernel kernel = new StandardKernel(serviceModule, repositoryModule);
            DependencyResolver.SetResolver(new NinjectDependencyResolver(kernel));

        }
    }
}
