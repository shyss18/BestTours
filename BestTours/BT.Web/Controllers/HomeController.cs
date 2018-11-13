using System.Web;
using System.Web.Mvc;
using BT.BusinessLogic.Interface;
using Microsoft.AspNet.Identity.Owin;

namespace BT.Web.Controllers
{
    public class HomeController : Controller
    {
        private IUserService UserService
        {
            get => HttpContext.GetOwinContext().GetUserManager<IUserService>();
        }

        public ActionResult Index()
        {
            return View();
        }

        [Authorize(Roles = "admin")]
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            return View();
        }
    }
}
