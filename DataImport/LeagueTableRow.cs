namespace FootballLeagueTable.DataImport
{
    public class LeagueTableRow
    {
        public string Team { get; set; }
        public int Won { get; set; }
        public int Drawn { get; set; }
        public int Lost { get; set; }
        public int For { get; set; }
        public int Against { get; set; }


        public int GetPlayed() {
            return Won + Drawn + Lost;
        }

        public int GetGoalDifference() {
            return For - Against;
        }

        public int GetPoints() {
            return Won*3 + Drawn;
        }
    }
}