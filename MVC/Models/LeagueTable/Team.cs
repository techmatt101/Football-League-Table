using System.ComponentModel.DataAnnotations;

namespace FootballLeagueTable.Models.LeagueTable
{
    public class Team
    {
        public int TeamId { get; set; }

        [Required]
        public string Name { get; set; }

        //public int Position { get; set; }

        public League League { get; set; }

        public MatchHistory MatchHistory { get; set; }
    }
}