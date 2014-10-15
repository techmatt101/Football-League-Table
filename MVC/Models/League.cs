using System.ComponentModel.DataAnnotations;

namespace FootballLeagueTable.Models
{
    public class League
    {
        public int LeagueId { get; set; }

        [Required]
        public string Name { get; set; }

        public MatchHistory[] MatchHistories { get; set; }
    }
}