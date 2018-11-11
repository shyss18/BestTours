using System.Linq;
using System.Web.Mvc;
using BT.BusinessLogic.Dependency;
using BT.BusinessLogic.Interface;
using BT.BusinessLogic.Services;
using BT.Dom.Entities;
using Ninject;

namespace BT.Web.Controllers
{
    public class TourController : Controller
    {
        private readonly ITourService _tourService;

        public TourController()
        {
            IKernel kernel = new StandardKernel(new TourServiceDependency());
            _tourService = kernel.Get<TourService>();
        }

        [HttpGet]
        [Route("/Tour/Index")]
        public ActionResult Index()
        {
            return View(_tourService.GetAll().Reverse());
        }

        [Authorize(Roles = "admin")]
        [HttpGet]
        public ActionResult AddTour()
        {
            return View();
        }

        [Authorize(Roles = "admin")]
        [HttpPost]
        public ActionResult AddTour(Tour model)
        {
            _tourService.CreateTour(model);

            return View(model);
        }

        [Authorize(Roles = "admin")]
        [HttpGet]
        public ActionResult EditTour(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            var tour = _tourService.GetById(id);

            return View(tour);
        }

        [HttpPost, ActionName("EditTour")]
        public ActionResult EditTourConfirmed(Tour model)
        {
            _tourService.EditTour(model);

            return RedirectToAction("Index");
        }

        [Authorize(Roles = "admin")]
        [HttpGet]
        public ActionResult DeleteTour(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            var tour = _tourService.GetById(id);

            return View(tour);
        }
        
        [HttpPost, ActionName("DeleteTour")]
        public ActionResult DeleteTourConfirmed(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            _tourService.DeleteTour(id);

            return RedirectToAction("Index");
        }
    }
}