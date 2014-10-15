﻿using System.Data.SqlClient;
using System.Linq;
using System.Web.Mvc;
using FootballLeagueTable.Models;
using FootballLeagueTable.Models.LeagueTable;

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
            var league = _db.Leagues.ToList()[leagueId - 1]; //TODO: ekk if no data
            league.Teams = _db.Teams.SqlQuery("SELECT * FROM Teams WHERE League_LeagueId = @leagueId", new SqlParameter("leagueId", leagueId)).ToArray();
            return View(league);
        }

        public ActionResult SelectTeam()
        {
            return View();
        }

        public ActionResult Compare()
        {
            var m = _db.MatchHistories.ToArray();
            var teams = _db.Teams.ToArray();
            return View(new CompareView(teams[0], teams[1]));
        }
    }
}