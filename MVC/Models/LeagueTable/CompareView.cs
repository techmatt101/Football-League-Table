using System;
using System.ComponentModel.DataAnnotations;

namespace FootballLeagueTable.Models.LeagueTable
{
    public class CompareView
    {
        public Team TeamOne;
        public Team TeamTwo;

        [Display(Name = "Point Difference")]
        public int PointDifference;

        [Display(Name = "Goal Difference")]
        public int GoalDifference;


        public CompareView(Team teamOne, Team teamTwo) {
            TeamOne = teamOne;
            TeamTwo = teamTwo;

            PointDifference = Math.Abs(TeamOne.MatchHistory.Points - TeamTwo.MatchHistory.Points);
            GoalDifference = Math.Abs(TeamOne.MatchHistory.GoalDifference - TeamTwo.MatchHistory.GoalDifference);
        }
    }
}