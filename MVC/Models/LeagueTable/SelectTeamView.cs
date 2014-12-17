using System.Collections.Generic;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;

namespace FootballLeagueTable.Models.LeagueTable
{
    public class SelectTeamView
    {
        [Display(Name = "Chosen League")]
        public int SelectedLeague { get; set; }
        public IEnumerable<SelectListItem> LeagueList { get; set; }

        [Display(Name = "Following Team")]
        public int SelectedFollowingTeam { get; set; }
        public IEnumerable<SelectListItem> FollowingTeamList { get; set; }

        [Display(Name = "Rival Team")]
        public int SelectedRivalTeam { get; set; }
        public IEnumerable<SelectListItem> RivalTeamList { get; set; }
    }
}