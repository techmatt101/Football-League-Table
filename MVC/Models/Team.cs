using System.ComponentModel.DataAnnotations;

namespace FootballLeagueTable.Models
{
    public class Team
    {
        public int TeamId { get; set; }

        [Required]
        public string Name { get; set; }

        public League League { get; set; }
    }
}