using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FootballLeagueTable.Models.LeagueTable
{
    public class Team
    {
        public int TeamId { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public int LeagueId { get; set; }

        [ForeignKey("LeagueId")]
        public virtual League League { get; set; }


        [Required]
        public int MatchHistoryId { get; set; }

        [ForeignKey("MatchHistoryId")]
        public virtual MatchHistory MatchHistory { get; set; }
    }
}