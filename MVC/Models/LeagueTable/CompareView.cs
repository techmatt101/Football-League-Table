namespace FootballLeagueTable.Models.LeagueTable
{
    public class CompareView
    {
        public Team TeamOne;
        public Team TeamTwo;
        public int PointDifference;

        public CompareView(Team teamOne, Team teamTwo)
        {
            TeamOne = teamOne;
            TeamTwo = teamTwo;

            PointDifference = TeamOne.MatchHistory.Points - TeamTwo.MatchHistory.Points;
        }
    }
}