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

        private static Dictionary<string, Boolean> _columnsTable = new Dictionary<string, bool>();
        private static string[] _columns;

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

            var values = line.Split(',');

            _columns = new string[values.Length];

            // Required Columns
            _columnsTable.Add("@Won", false);
            _columnsTable.Add("@Drawn", false);
            _columnsTable.Add("@Lost", false);
            _columnsTable.Add("@For", false);
            _columnsTable.Add("@Against", false);

            for (var i = 0; i < values.Length; i++) {
                var columnKey = GetColumnKey(values[i]);
                _columns[i] = columnKey;
                if(columnKey != null)
                    _columnsTable[columnKey] = true;
            }

            if (_columnsTable.ContainsValue(false)) {
                var missingColumns = string.Join(", ", (from column in _columnsTable where !column.Value select column.Key));
                Console.Error.WriteLine("Missing Required Columns " + missingColumns);
                return 1;
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

                var lineNumber = 1;
                while (!sr.EndOfStream) {
                    values = sr.ReadLine().Split(',');
                    lineNumber++;

                    //skip blank lines
                    if (values.Length == 0) {
                        continue;
                    }

                    if (values.Length != _columns.Length) {
                        Console.WriteLine(new WarningException("Syntax Error on line " + lineNumber + ". Skipping line for data import."));
                        continue;
                    }

                    var command = new SqlCommand(query, sqlCon);

                    for (var i = 0; i < values.Length; i++) {
                        if (_columns[i] == null)
                            continue;
                        command.Parameters.AddWithValue(_columns[i], values[i]);
                    }

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

        private static string GetColumnKey(string value) {
            switch (value.ToLower()) {
                case "place":
                case "pos":
                case "position":
                    return "@Place";

                case "team":
                    return "@Team";

                case "p":
                case "played":
                    return "@Played";

                case "w":
                case "won":
                case "win":
                    return "@Won";

                case "d":
                case "draw":
                case "drawn":
                    return "@Drawn";

                case "l":
                case "lost":
                case "lose":
                    return "@Lost";

                case "f":
                case "for":
                    return "@For";

                case "a":
                case "against":
                    return "@Against";

                case "gd":
                case "goal difference":
                    return "@GoalDifference";

                case "pts":
                case "points":
                case "score":
                    return "@Points";

                default:
                    Console.WriteLine(new WarningException("Column '" + value + "' not supported. Skipping column for data import."));
                    return null;
            }
        }
    }
}