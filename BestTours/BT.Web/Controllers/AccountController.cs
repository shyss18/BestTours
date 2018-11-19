using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using BT.BusinessLogic.DTO;
using BT.BusinessLogic.Infrastructure;
using BT.BusinessLogic.Interface;
using BT.Web.Models;
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

            return RedirectToAction("Register");
        }

        [HttpGet]
        [Route("Account/Cabinet")]
        public ActionResult Cabinet(string name)
        {
            if (name == null)
            {
                return HttpNotFound();
            }

            var user = _userService.GetByNameUserDto(name);

            AccountModel userAccount = new AccountModel
            {
                NickName = user.NickName,
                Email = user.Email,
                Amount = user.Amount,
                FirstName = user.FirstName,
                LastName = user.LastName
            };

            return View(userAccount);
        }

        [HttpGet]
        [Route("Account/EditAccount")]
        public ActionResult EditAccount(string name)
        {
            if (name == null)
            {
                return HttpNotFound();
            }

            var user = _userService.GetByNameUserDto(name);

            AccountModel account = new AccountModel
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                Amount = user.Amount,
                Email = user.Email,
                NickName = user.NickName
            };

            return View(account);
        }

        [HttpPost]
        [Route("Account/EditAccount")]
        public ActionResult EditAccount(AccountModel model)
        {
            var user = _userService.GetByNameUser(User.Identity.Name);

            if (user != null)
            {
                user.FirstName = model.FirstName;
                user.LastName = model.LastName;
                user.Amount = model.Amount;
                user.Email = model.Email;
                user.UserName = model.NickName;

                _userService.UpdateUser(user);

                return RedirectToAction("Cabinet", "Account", user.UserName);
            }

            return View("Error");
        }
    }
}