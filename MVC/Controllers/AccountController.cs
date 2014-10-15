using System.Web.Mvc;

namespace FootballLeagueTable.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        [AllowAnonymous]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        //[ValidateAntiForgeryToken]
        public ActionResult Login(string returnUrl)
        {
            return RedirectToAction("Index", "Home");
        }

        //[HttpPost]
        //[AllowAnonymous]
        //[ValidateAntiForgeryToken]
        //public async Task<ActionResult> Login(LoginView model, string returnUrl)
        //{
        //    return View(model);
        //}

        [AllowAnonymous]
        public ActionResult Register()
        {
            return View();
        }

        //[HttpPost]
        //[AllowAnonymous]
        //[ValidateAntiForgeryToken]
        //public async Task<ActionResult> Register(RegisterView model)
        //{
        //    return View(model);
        //}
        
        //[ValidateAntiForgeryToken]
        public ActionResult Logout()
        {
            return RedirectToAction("Index", "Home");
        }
    }
}