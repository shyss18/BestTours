using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using BT.BusinessLogic.DTO;
using BT.BusinessLogic.Infrastructure;
using BT.BusinessLogic.Interface;
using BT.Web.Models;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;

namespace BT.Web.Controllers
{
    public class AccountController : Controller
    {
        private IUserService UserService
        {
            get => HttpContext.GetOwinContext().Get<IUserService>();
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
            await UserService.SetInitialDataAsync();

            if (ModelState.IsValid)
            {
                UserDTO user = new UserDTO { NickName = model.NickName, Password = model.Password };
                ClaimsIdentity claim = await UserService.Authenticate(user);
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
            await UserService.SetInitialDataAsync();

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

                OperationDetails operationDetails = await UserService.Create(user);
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

            var user = UserService.GetByName(name);

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

            var user = UserService.GetByName(name);

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
            UserDTO user = new UserDTO
            {
                NickName = model.NickName,
                FirstName = model.FirstName,
                LastName = model.LastName,
                Email = model.Email,
                Amount = model.Amount
            };

            UserService.UpdateUser(user);

            return RedirectToAction("Index", "Home");
        }
    }
}