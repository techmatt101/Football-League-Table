using System.ComponentModel.DataAnnotations;

namespace FootballLeagueTable.Models.LeagueTable
{
    public class League
    {
        public int LeagueId { get; set; }

        [Required]
        public string Name { get; set; }

        public Team[] Teams { get; set; }
    }
}