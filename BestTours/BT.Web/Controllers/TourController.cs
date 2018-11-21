using System;
using System.Linq;
using System.Web.Mvc;
using BT.BusinessLogic.Interface;
using BT.Dom.Entities;

namespace BT.Web.Controllers
{
    public class TourController : Controller
    {
        private readonly ITourService _tourService;
        private readonly IUserService _userService;

        public TourController(ITourService tourService, IUserService userService)
        {
            _tourService = tourService;
            _userService = userService;
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
        [ValidateAntiForgeryToken]
        public ActionResult AddTour(Tour model)
        {
            if (ModelState.IsValid)
            {
                _tourService.CreateTour(model);

                return RedirectToAction("Index", "Tour");
            }       

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

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditTour(Tour model)
        {
            if (ModelState.IsValid)
            {
                _tourService.EditTour(model);

                return RedirectToAction("Index");
            }

            return View(model);
        }

        [Authorize(Roles = "admin")]
        [HttpPost, ActionName("DeleteTour")]
        public ActionResult DeleteTour(int? id)
        {
            if (id == null)
            {
                return View("Error");
            }

            _tourService.DeleteTour(id);

            return RedirectToAction("Index");
        }

        [HttpGet]
        [Authorize]
        public ActionResult BuyTour(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            var tour = _tourService.GetById(id);

            return View(tour);
        }

        [HttpPost]
        public ActionResult BuyTour(int? id, string userId)
        {
            if (userId == null)
            {
                return HttpNotFound();
            }

            var model = _tourService.GetById(id);

            if (_tourService.BuyTour(model, userId))
            {
                return RedirectToAction("Index");
            }

            return View(model);
        }

        [HttpGet]
        [Authorize]
        public ActionResult ToursCurrentUser(string id)
        {
            if (id == null)
            {
                return View("Error");
            }

            var user = _userService.GetById(id);
            
            return View(user);
        }

        [HttpGet]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return View("Error");
            }

            var tour = _tourService.GetById(id);

            return View(tour);
        }

        public JsonResult ValidateDate(string Date)
        {
            DateTime parsedDate;

            if (!DateTime.TryParse(Date, out parsedDate))
            {
                return Json("Пожалуйста, введите дату в формате (мм.дд.гггг)",
                    JsonRequestBehavior.AllowGet);
            }
            else if (DateTime.Now > parsedDate)
            {
                return Json("Введите дату относящуюся к будущему",
                    JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(true, JsonRequestBehavior.AllowGet);
            }
        }
    }
}