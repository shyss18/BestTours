using System.Web.Mvc;
using BT.BusinessLogic.Interface;
using BT.Dom.Entities;

namespace BT.Web.Controllers
{
    public class HotelController : Controller
    {
        private readonly IHotelService _hotelService;

        public HotelController(IHotelService hotelService)
        {
            _hotelService = hotelService;
        }

        [HttpGet]
        public ActionResult AllHotels()
        {
            return View(_hotelService.GetAll());
        }

        [HttpGet]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return View("Error");
            }

            var hotel = _hotelService.GetById(id);

            return View(hotel);
        }

        [HttpGet]
        [Authorize(Roles = "admin")]
        public ActionResult CreateHotel()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateHotel(Hotel model)
        {
            if (ModelState.IsValid)
            {
                _hotelService.CreateHotel(model);

                return RedirectToAction("Details", new { id = model.Id });
            }

            return View(model);
        }

        [HttpGet]
        [Authorize(Roles = "admin")]
        public ActionResult EditHotel(int? id)
        {
            if (id == null)
            {
                return View("Error");
            }

            var hotel = _hotelService.GetById(id);

            return View(hotel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditHotel(Hotel model)
        {
            if (ModelState.IsValid)
            {
                _hotelService.UpdateHotel(model);

                return RedirectToAction("Details", new { id = model.Id });
            }

            return View(model);
        }

        [Authorize(Roles = "admin")]
        [HttpPost]
        public ActionResult DeleteHotel(int? id)
        {
            if (id == null)
            {
                return View("Error");
            }

            _hotelService.DeleteHotel(id);

            return RedirectToAction("AllHotels");
        }
    }
}