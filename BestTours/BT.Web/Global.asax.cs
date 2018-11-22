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

            NinjectModule dataAccessModule = new DataAccessModule();
            NinjectModule businessLogicModule = new BusinessLogicModule();
            IKernel kernel = new StandardKernel(dataAccessModule, businessLogicModule);
            DependencyResolver.SetResolver(new NinjectDependencyResolver(kernel));
        }
    }
}
