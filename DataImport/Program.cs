using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;
using System.IO;
using System.Linq;

namespace FootballLeagueTable.DataImport
{
    internal class Program
    {
        private const string DbCatalog = @"TeamTrackerDemoDb";
        private const string DbPath = @"C:\Users\Matthew\Documents\GitHub\Football-League-Table\MVC\App_Data\" + DbCatalog + ".mdf";


        private static int Main(string[] args) {
            if (args.Length == 0 || !args[0].EndsWith(".csv")) {
                Console.Error.WriteLine("CSV file not pased");
                return 1;
            }

            var filePath = args[0];

            if (!File.Exists(filePath)) {
                Console.Error.WriteLine(filePath + " file does not exist");
                return 1;
            }

            var sr = new StreamReader(filePath);


            // Setup Columns
            var line = sr.ReadLine();

            if (line == null) {
                Console.Error.WriteLine("Emtpy File");
                return 1;
            }

            var columns = line.Split(',');
            var leagueTable = new List<LeagueTableRow>();

            // Read Values
            var lineNumber = 1;
            while (!sr.EndOfStream) {
                var values = sr.ReadLine().Split(',');
                lineNumber++;

                //skip blank lines
                if (values.Length == 0) {
                    continue;
                }

                if (values.Length != columns.Length) {
                    Console.WriteLine(new WarningException("Syntax Error on line " + lineNumber + ". Skipping line for data import."));
                    continue;
                }

                var newLeagueTable = new LeagueTableRow();
                for (var i = 0; i < values.Length; i++) {
                    InsertData(values[i], columns[i], newLeagueTable, lineNumber != 2);
                }

                if (newLeagueTable.Team == "") 
                    continue;

                leagueTable.Add(newLeagueTable);
            }

            //Import Data
            using (var sqlCon = new SqlConnection(@"Data Source=(LocalDb)\v11.0;AttachDbFilename=" + DbPath + ";Initial Catalog=" + DbCatalog + ";Integrated Security=True")) {
                try {
                    sqlCon.Open();
                }
                catch (Exception e) {
                    Console.Error.WriteLine("Unable to connect to Databse\n");
                    Console.Error.WriteLine(e);
                    return 1;
                }

                var query = File.ReadAllText(@"C:\Users\Matthew\Documents\GitHub\Football-League-Table\DataImport\LeageTableUpdateQuery.sql");

                for (var i = 0; i < leagueTable.Count; i++) {
                    var command = new SqlCommand(query, sqlCon);

                    command.Parameters.AddWithValue("@Team", leagueTable[i].Team);
                    command.Parameters.AddWithValue("@Position", i);
                    command.Parameters.AddWithValue("@Played", leagueTable[i].GetPlayed());
                    command.Parameters.AddWithValue("@Won", leagueTable[i].Won);
                    command.Parameters.AddWithValue("@Drawn", leagueTable[i].Drawn);
                    command.Parameters.AddWithValue("@Lost", leagueTable[i].Lost);
                    command.Parameters.AddWithValue("@For", leagueTable[i].For);
                    command.Parameters.AddWithValue("@Against", leagueTable[i].Against);
                    command.Parameters.AddWithValue("@GoalDifference", leagueTable[i].GetGoalDifference());
                    command.Parameters.AddWithValue("@Points", leagueTable[i].GetPoints());

                    try {
                        command.ExecuteNonQuery();
                    }
                    catch (Exception e) {
                        Console.Error.WriteLine("Unexpected SQL Query Error\n");
                        Console.Error.WriteLine(e);
                        return 1;
                    }
                }

                sqlCon.Close();
            }

            Console.WriteLine("Successfully Imported " + filePath);

            return 0;
        }

        private static void InsertData(string value, string column, LeagueTableRow leagueTableRow, Boolean silence = false)
        {
            switch (column.ToLower()) {
                case "team":
                    leagueTableRow.Team = value.Replace('_', ' ').Replace('-', ' ');
                    break;

                case "w":
                case "won":
                case "win":
                    leagueTableRow.Won = Convert.ToInt32(value);
                    break;

                case "d":
                case "draw":
                case "drawn":
                    leagueTableRow.Drawn = Convert.ToInt32(value);
                    break;

                case "l":
                case "lost":
                case "lose":
                    leagueTableRow.Lost = Convert.ToInt32(value);
                    break;

                case "f":
                case "for":
                    leagueTableRow.For = Convert.ToInt32(value);
                    break;

                case "a":
                case "against":
                    leagueTableRow.Against = Convert.ToInt32(value);
                    break;

                case "place":
                case "pos":
                case "position":

                case "p":
                case "played":

                case "gd":
                case "goal difference":

                case "pts":
                case "points":
                case "score":
                    if (!silence)
                        Console.WriteLine(new WarningException("Column '" + column + "' ignored. Skipping column for data import."));
                    break;

                default:
                    if (!silence)
                        Console.WriteLine(new WarningException("Column '" + column + "' not supported. Skipping column for data import."));
                    break;
            }
        }
    }
}