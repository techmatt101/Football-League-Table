using System.Web;
using System.Web.Mvc;
using FootballLeagueTable.Models;
using Microsoft.Owin.Security;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using FootballLeagueTable.Models.Account;

namespace FootballLeagueTable.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        public AccountController() : this(new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new TeamTrackerDb()))) {
        }

        public AccountController(UserManager<ApplicationUser> userManager) {
            UserManager = userManager;
        }

        public UserManager<ApplicationUser> UserManager { get; private set; }

        private IAuthenticationManager AuthManager {
            get { return HttpContext.GetOwinContext().Authentication; }
        }

        [AllowAnonymous]
        public ActionResult Login() {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginView model) {
            if (ModelState.IsValid) {
                var user = UserManager.Find(model.Username, model.Password);
                if (user != null) {
                    SignIn(user, true);
                    return RedirectToAction("Index", "Home");
                }
                else {
                    ModelState.AddModelError("", "Invalid username or password.");
                }
            }

            return View(model);
        }

        [AllowAnonymous]
        public ActionResult Register() {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Register(RegisterView model) {
            if (ModelState.IsValid) {
                var user = new ApplicationUser() {
                    UserName = model.Username,
                    Email = model.Email
                };
                var result = UserManager.Create(user, model.Password);
                if (result.Succeeded) {
                    SignIn(user, true);
                    return RedirectToAction("Index", "Home");
                }
                else {
                    AddModelErrors(result);
                }
            }

            return View(model);
        }

        public ActionResult Logout() {
            AuthManager.SignOut();
            return RedirectToAction("Index", "Home");
        }

        private void SignIn(ApplicationUser user, bool isPersistent) {
            AuthManager.SignOut(DefaultAuthenticationTypes.ExternalCookie);
            var identity = UserManager.CreateIdentity(user, DefaultAuthenticationTypes.ApplicationCookie);
            AuthManager.SignIn(new AuthenticationProperties() {IsPersistent = isPersistent}, identity);
        }

        private void AddModelErrors(IdentityResult result) {
            foreach (var error in result.Errors) {
                ModelState.AddModelError("", error);
            }
        }
    }
}