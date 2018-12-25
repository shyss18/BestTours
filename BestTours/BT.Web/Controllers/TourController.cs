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
        private readonly IHotelService _hotelService;

        public TourController(ITourService tourService, IUserService userService, IHotelService hotelService)
        {
            _tourService = tourService;
            _userService = userService;
            _hotelService = hotelService;
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
            SelectList hotels = new SelectList(_hotelService.GetAll(), "Id", "Name");
            ViewBag.Hotels = hotels;

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
            SelectList hotels = new SelectList(_hotelService.GetAll(), "Id", "Name");
            ViewBag.Hotels = hotels;

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
        [HttpPost]
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

            var modelUser = model.Users.FirstOrDefault(u => u.Id == userId);

            if (modelUser != null)
            {
                return View("TourThere");             
            }

            if (_tourService.BuyTour(model, userId))
            {
                return View("BuySucceded");
            }

            return View("BuyFailed");
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