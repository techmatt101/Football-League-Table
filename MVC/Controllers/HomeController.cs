using System.Web.Mvc;

namespace FootballLeagueTable.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}