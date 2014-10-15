using System.ComponentModel.DataAnnotations;

namespace FootballLeagueTable.Models.LeagueTable
{
    public class MatchHistory
    {
        public int MatchHistoryId { get; set; }

        [Display(Name = "P")]
        public int Played { get; set; }

        [Display(Name = "W")]
        public int Won { get; set; }

        [Display(Name = "D")]
        public int Drawn { get; set; }

        [Display(Name = "L")]
        public int Lost { get; set; }

        [Display(Name = "F")]
        public int For { get; set; }

        [Display(Name = "A")]
        public int Against { get; set; }

        [Display(Name = "GD")]
        public int Difference { get; set; }

        [Display(Name = "Pts")]
        public int Points { get; set; }
    }
}