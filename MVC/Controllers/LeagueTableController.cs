using System.Linq;
using System.Web.Mvc;
using FootballLeagueTable.Models;
using FootballLeagueTable.Models.LeagueTable;

namespace FootballLeagueTable.Controllers
{
    [Authorize]
    public class LeagueTableController : Controller
    {
        private readonly TeamTrackerDb _db = new TeamTrackerDb();

        [AllowAnonymous]
        public ActionResult Overview() {
            const int leagueId = 1;
            var a = _db.MatchHistories.ToList(); //TODO: how does this even fix the data?
            var league = _db.Leagues.ToList()[leagueId - 1]; //TODO: ekk if no data
            league.Teams = _db.Teams.Where(team => team.League.LeagueId == leagueId).ToArray();
            return View(league);
        }

        public ActionResult SelectTeam() {
            var teams = _db.Teams.ToArray();
            return View(new SelectTeamView(teams, new UserFollowings()));
        }

        public ActionResult Compare() {
            var m = _db.MatchHistories.ToArray(); //TODO: how does this even fix the data?
            var teams = _db.Teams.ToArray();
            return View(new CompareView(teams[0], teams[1]));
        }

        #region Dispose
        protected override void Dispose(bool disposing) {
            if (disposing) {
                _db.Dispose();
            }
            base.Dispose(disposing);
        }
        #endregion
    }
}