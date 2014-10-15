using System.Data.SqlClient;
using System.Linq;
using System.Web.Mvc;
using FootballLeagueTable.Models;

namespace FootballLeagueTable.Controllers
{
    public class LeagueTableController : Controller
    {
        private readonly ApplicationDbContext _db = new ApplicationDbContext();

        protected override void Dispose(bool disposing)
        {
            if (disposing) {
                _db.Dispose();
            }
            base.Dispose(disposing);
        }

        public ActionResult Overview()
        {
            const int leagueId = 1;
            var teams = _db.Teams.ToArray(); //TODO: yep have no clue, but makes team names appear in data
            var league = _db.Leagues.ToList()[leagueId - 1]; //TODO: ekk if no data
            //league.MatchHistories = _db.MatchHistories.SqlQuery("SELECT * FROM MatchHistories WHERE League_LeagueId = @leagueId", new SqlParameter("leagueId", leagueId)).ToArray();
            league.MatchHistories = _db.MatchHistories.ToArray();
            return View(league);
        }

        public ActionResult SelectTeam()
        {
            return View();
        }

        public ActionResult CompareTeams()
        {
            return View();
        }
    }
}
