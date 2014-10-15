using System.ComponentModel.DataAnnotations;

namespace FootballLeagueTable.Models.Account
{
    public class User
    {
        public string UserId { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        public Team FollowingTeam { get; set; }
        public Team RivalTeam { get; set; }
    }
}