using System.ComponentModel.DataAnnotations;

namespace FootballLeagueTable.Models.LeagueTable
{
    public class UserFollowings
    {
        public int UserFollowingsId { get; set; }

        [Required]
        public ApplicationUser UserId { get; set; }

        public Team FollowingTeam { get; set; }
        public Team RivalTeam { get; set; }
    }
}