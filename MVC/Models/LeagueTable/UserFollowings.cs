using System.ComponentModel.DataAnnotations.Schema;

namespace FootballLeagueTable.Models.LeagueTable
{
    public class UserFollowings
    {
        public int UserFollowingsId { get; set; }

        public int? SelectedLeagueId { get; set; }
        [ForeignKey("SelectedLeagueId")]
        public virtual League SelectedLeague { get; set; }


        public int? FollowingTeamId { get; set; }
        [ForeignKey("FollowingTeamId")]
        public virtual Team FollowingTeam { get; set; }


        public int? RivalTeamId { get; set; }
        [ForeignKey("RivalTeamId")]
        public virtual Team RivalTeam { get; set; }
    }
}