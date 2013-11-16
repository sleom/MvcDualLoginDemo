using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using MvcDualLoginDemo.Models;

namespace MvcDualLoginDemo.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {

        protected IMembershipService MembershipService { get; private set; }
        protected IAuthenticationService AuthenticationService { get; private set; }

        public AccountController(IMembershipService membershipService, IAuthenticationService authenticationService)
        {
            MembershipService = membershipService;
            AuthenticationService = authenticationService;
        }

        public AccountController():this(new AppMembershipService(), new AppAuthenticationService())
        {
        }

        [AllowAnonymous]
        public ActionResult LogIn()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public ActionResult LogIn(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                if (MembershipService.ValidateUser(model.UserName, model.Password))
                {
                    AuthenticationService.SignIn(model.UserName, model.IsPrimary);
                }
                return RedirectToAction("Index", "Status");
            }
            return View(model);
        }

    }
}
