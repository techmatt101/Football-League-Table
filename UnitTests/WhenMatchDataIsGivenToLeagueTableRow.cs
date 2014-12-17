using Microsoft.VisualStudio.TestTools.UnitTesting;
using FootballLeagueTable.DataImport;

namespace FootballLeagueTable.Tests
{
    [TestClass]
    public class WhenMatchDataIsGivenToLeagueTableRow
    {
        private LeagueTableRow _leagueTableRow;

        [TestInitialize]
        public void Setup() {
            _leagueTableRow = new LeagueTableRow {
                Team = "MK Dons",
                Won = 4,
                Drawn = 2,
                Lost = 7,
                For = 21,
                Against = 11
            };
        }

        [TestMethod]
        public void ThatGetPlayedReturnsTheCorrectNumberOfGamesPlayedBasedOffWonDrawnAndLostGames() {
            Assert.AreEqual(13, _leagueTableRow.GetPlayed());
        }

        [TestMethod]
        public void ThatGetGoalDifferenceReturnsTheCorrectNumberOfGamesPlayedBasedOffWonDrawnAndLostGames() {
            Assert.AreEqual(10, _leagueTableRow.GetGoalDifference());
        }

        [TestMethod]
        public void ThatGetPointsReturnsTheCorrectNumberOfGamesPlayedBasedOffWonDrawnAndLostGames() {
            Assert.AreEqual(14, _leagueTableRow.GetPoints());
        }
    }
}