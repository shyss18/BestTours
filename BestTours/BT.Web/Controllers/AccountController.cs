using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using BT.BusinessLogic.DTO;
using BT.BusinessLogic.Infrastructure;
using BT.BusinessLogic.Interface;
using BT.Web.Models;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;

namespace BT.Web.Controllers
{
    public class AccountController : Controller
    {
        private readonly IUserService _userService;

        public AccountController(IUserService userService)
        {
            _userService = userService;
        }

        private IAuthenticationManager AuthenticationManager
        {
            get => HttpContext.GetOwinContext().Authentication;
        }

        [HttpGet]
        [Route("/Account/Login")]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [Route("/Account/Login")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Login(LoginModel model)
        {
            await _userService.SetInitialDataAsync();

            if (ModelState.IsValid)
            {
                UserDTO user = new UserDTO { NickName = model.NickName, Password = model.Password };
                ClaimsIdentity claim = await _userService.Authenticate(user);
                if (claim == null)
                {
                    ModelState.AddModelError("", "Неверный логин или пароль");
                }
                else
                {
                    AuthenticationManager.SignOut();
                    AuthenticationManager.SignIn(new AuthenticationProperties
                    {
                        IsPersistent = true
                    }, claim);

                    return RedirectToAction("Index", "Home");
                }
            }

            return View();
        }

        public ActionResult LogOut()
        {
            AuthenticationManager.SignOut();
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [Route("/Acount/Register")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Register(RegisterModel model)
        {
            await _userService.SetInitialDataAsync();

            if (ModelState.IsValid)
            {
                UserDTO user = new UserDTO
                {
                    NickName = model.Name,
                    Email = model.Email,
                    Password = model.Password,
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    Role = "user"
                };

                OperationDetails operationDetails = await _userService.Create(user);
                if (operationDetails.Succedeed)
                {
                    return View("SuccessRegister");
                }
                else
                {
                    ModelState.AddModelError(operationDetails.Property, operationDetails.Message);
                }
            }

            return View(model);
        }

        [HttpGet]
        [Route("Account/Cabinet")]
        public ActionResult Cabinet(string id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            var user = _userService.GetById(id);

            AccountModel userAccount = new AccountModel
            {
                NickName = user.UserName,
                Email = user.Email,
                Amount = user.Amount,
                FirstName = user.FirstName,
                LastName = user.LastName
            };

            return View(userAccount);
        }

        [HttpGet]
        [Route("Account/EditAccount")]
        public ActionResult EditAccount(string id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            var user = _userService.GetById(id);

            AccountModel account = new AccountModel
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                Amount = user.Amount,
                Email = user.Email
            };

            return View(account);
        }

        [HttpPost]
        [Route("Account/EditAccount")]
        public ActionResult EditAccount(AccountModel model)
        {
            var user = _userService.GetById(User.Identity.GetUserId());

            if (user == null)
            {
                return View("Error");
            }

            if (ModelState.IsValid)
            {
                user.FirstName = model.FirstName;
                user.LastName = model.LastName;
                user.Amount = model.Amount;
                user.Email = model.Email;

                _userService.UpdateUser(user);

                return RedirectToAction("Cabinet", "Account", new { id = user.Id });
            }

            return View(model);
        }

        public JsonResult CheckUserName(string Name)
        {
            var user = _userService.GetByUserName(Name);

            if (user != null && user.Id != User.Identity.GetUserId())
            {
                return Json("Данный никнейм уже занят", JsonRequestBehavior.AllowGet);
            }

            return Json(true, JsonRequestBehavior.AllowGet);
        }

        public JsonResult CheckUserEmail(string Email)
        {
            var user = _userService.GetByUserEmail(Email);

            if (user != null & user.Id != User.Identity.GetUserId())
            {
                return Json("Пользователь с таким адресом уже существует", JsonRequestBehavior.AllowGet);
            }

            return Json(true, JsonRequestBehavior.AllowGet);
        }
    }
}