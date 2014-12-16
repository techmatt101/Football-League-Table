using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FootballLeagueTable.Models.LeagueTable
{
    public class MatchHistory
    {
        public int MatchHistoryId { get; set; }

        [Index]
        [Display(Name = "Position")]
        public int Position { get; set; }

        [Display(Name = "P", Description = "Matches played")]
        public int Played { get; set; }

        [Display(Name = "W", Description = "Matches won")]
        public int Won { get; set; }

        [Display(Name = "D", Description = "Matches drawn")]
        public int Drawn { get; set; }

        [Display(Name = "L", Description = "Matches lost")]
        public int Lost { get; set; }

        [Display(Name = "F", Description = "Matches goals for")]
        public int For { get; set; }

        [Display(Name = "A", Description = "Matches goals against")]
        public int Against { get; set; }

        [Display(Name = "GD", Description = "Goal difference")]
        public int GoalDifference { get; set; }

        [Display(Name = "Pts", Description = "Points")]
        public int Points { get; set; }
    }
}