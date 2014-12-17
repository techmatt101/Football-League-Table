using System.Web;
using System.Web.Mvc;
using FootballLeagueTable.Models;
using FootballLeagueTable.Models.LeagueTable;
using Microsoft.Owin.Security;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using FootballLeagueTable.Models.Account;

namespace FootballLeagueTable.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        public AccountController() : this(new UserManager<UserAccount>(new UserStore<UserAccount>(new TeamTrackerDb()))) {
        }

        public AccountController(UserManager<UserAccount> userManager) {
            UserManager = userManager;
        }

        public UserManager<UserAccount> UserManager { get; private set; }

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
                    return RedirectToAction("Overview", "LeagueTable");
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
                var user = new UserAccount() {
                    UserName = model.Username,
                    Email = model.Email,
                    UserFollowings = new UserFollowings() {
                        FollowingTeamId = 1,
                        RivalTeamId = 2
                    }
                };
                var result = UserManager.Create(user, model.Password);
                if (result.Succeeded) {
                    SignIn(user, true);

                    return RedirectToAction("SelectTeam", "LeagueTable");
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

        private void SignIn(UserAccount userAccount, bool isPersistent) {
            AuthManager.SignOut(DefaultAuthenticationTypes.ExternalCookie);
            var identity = UserManager.CreateIdentity(userAccount, DefaultAuthenticationTypes.ApplicationCookie);
            AuthManager.SignIn(new AuthenticationProperties() {IsPersistent = isPersistent}, identity);
        }

        private void AddModelErrors(IdentityResult result) {
            foreach (var error in result.Errors) {
                ModelState.AddModelError("", error);
            }
        }
    }
}