using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using FootballLeagueTable.Models;
using FootballLeagueTable.Models.Account;
using FootballLeagueTable.Models.LeagueTable;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace FootballLeagueTable.Controllers
{
    [Authorize]
    public class LeagueTableController : Controller
    {
        protected UserManager<UserAccount> UserManager { get; set; }
        protected TeamTrackerDb Db;

        public LeagueTableController() {
            Db = new TeamTrackerDb();
            UserManager = new UserManager<UserAccount>(new UserStore<UserAccount>(Db));
        }

        [AllowAnonymous]
        [Route("LeagueTable")]
        public ActionResult Overview() {
            var league = User.Identity.IsAuthenticated ? GetCurrentUser().UserFollowings.SelectedLeague : Db.Leagues.First();
            league.Teams = Db.Teams.Where(team => team.League.LeagueId == league.LeagueId).ToArray();

            return View(league);
        }

        [Route("MyTeams")]
        public ActionResult SelectTeam() {
            var usersFollowings = GetCurrentUser().UserFollowings;
            var leagueId = usersFollowings.SelectedLeagueId ?? 0;

            var model = new SelectTeamView {
                LeagueList = Db.Leagues.Select((league => new SelectListItem() {
                    Text = league.Name,
                    Value = league.LeagueId.ToString()
                })),
                SelectedLeague = leagueId,
                FollowingTeamList = Db.Teams.
                Where(team => team.League.LeagueId == leagueId).
                Select((team => new SelectListItem() {
                    Text = team.Name,
                    Value = team.TeamId.ToString()
                })),
                SelectedFollowingTeam = usersFollowings.FollowingTeamId ?? 0,
                RivalTeamList = Db.Teams.
                Where(team => team.League.LeagueId == leagueId).
                Select((team => new SelectListItem() {
                    Text = team.Name,
                    Value = team.TeamId.ToString()
                })),
                SelectedRivalTeam = usersFollowings.RivalTeamId ?? 0
            };

            return View(model);
        }

        [HttpPost]
        [Route("MyTeams")]
        public ActionResult SelectTeam(SelectTeamView model) {
            var usersFollowings = GetCurrentUser().UserFollowings;

            usersFollowings.SelectedLeagueId = model.SelectedLeague;
            usersFollowings.FollowingTeamId = model.SelectedFollowingTeam;
            usersFollowings.RivalTeamId = model.SelectedRivalTeam;

            Db.Entry(usersFollowings).State = EntityState.Modified;
            Db.SaveChanges();

            return SelectTeam();
        }

        [Route("CompareTeams")]
        public ActionResult Compare() {
            var usersFollowings = GetCurrentUser().UserFollowings;
            return View(new CompareView(usersFollowings.FollowingTeam, usersFollowings.RivalTeam));
        }

        private UserAccount GetCurrentUser() {
            return UserManager.FindById(User.Identity.GetUserId());
        }

        #region Dispose

        protected override void Dispose(bool disposing) {
            if (disposing) {
                Db.Dispose();
            }
            base.Dispose(disposing);
        }

        #endregion
    }
}