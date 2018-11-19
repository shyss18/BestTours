using System.Web.Mvc;
using System.Web.Routing;

namespace BT.Web
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Login",
                url: "Account/Login"
            );

            routes.MapRoute(
                name: "MainPage",
                url: "Home/Index"
            );

            routes.MapRoute(
                name: "LogOut",
                url: "Account/LogOut"
            );

            routes.MapRoute(
                name: "Register",
                url: "Account/Register"
            );

            routes.MapRoute(
                name: "AddTour",
                url: "Tour/AddTour"
            );

            routes.MapRoute(
                name: "AllTours",
                url: "Tour/Index"
                );

            routes.MapRoute(
                name: "Cabinet",
                url: "Account/Cabinet"
                );

            routes.MapRoute(
                name: "BuyTour",
                url: "Tour/BuyTour"
                );
        }
    }
}
