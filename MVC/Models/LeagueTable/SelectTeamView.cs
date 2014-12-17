using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;

namespace FootballLeagueTable.Models.LeagueTable
{
    public class SelectTeamView
    {
        [Display(Name = "Following Team")]
        public int SelectedFollowingTeam { get; set; }
        public IEnumerable<SelectListItem> FollowingTeamList { get; set; }

        [Display(Name = "Following Team")]
        public int SelectedRivalTeamList { get; set; }
        public IEnumerable<SelectListItem> RivalTeamList { get; set; }
    }
}