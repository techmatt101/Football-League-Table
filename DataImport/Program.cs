using System;
using System.IO;

namespace FootballLeagueTable.DataImport
{
    class Program
    {
        static int Main(string[] args)
        {
            if (args.Length == 0 || !args[0].EndsWith(".csv")) {
                Console.WriteLine("CSV file not pased");
                return 1;
            }

            string filepath = args[0];

            if (!File.Exists(filepath)) {
                Console.WriteLine(filepath + " file does not exist");
                return 1;
            }

            StreamReader sr = new StreamReader(filepath);
            string line = sr.ReadLine();
            string[] value = line.Split(',');

            //SqlConnection con = new SqlConnection(@"Data Source=(LocalDb)\v11.0;AttachDbFilename=C:\Users\Matthew\Documents\GitHub\Football-League-Table\Source\App_Data\aspnet-FootballLeagueTable-20140927072622.mdf;Initial Catalog=aspnet-FootballLeagueTable-20140927072622;Integrated Security=True");

            //foreach (string dc in value)
            //{
            //    dt.Columns.Add(new DataColumn(dc));
            //}

            //while (!sr.EndOfStream)
            //{
            //    value = sr.ReadLine().Split(',');
            //    if (value.Length == dt.Columns.Count)
            //    {
            //        row = dt.NewRow();
            //        row.ItemArray = value;
            //        dt.Rows.Add(row);
            //    }
            //}

            //try
            //{

            //}
            //catch(Exception e) {
            //    Console.WriteLine(e);
            //    Console.WriteLine("Import failed");
            //    return 1;
            //}   

            Console.WriteLine("Successfully Imported " + filepath);
            return 0;

            //SqlConnection con = new SqlConnection(@"Data Source=SHAWHP\SQLEXPRESS;Initial Catalog=FOO;Persist Security Info=True;User ID=sa");
            //SqlConnection con = new SqlConnection(@"Data Source=(LocalDb)\v11.0;AttachDbFilename=C:\Users\Matthew\Documents\GitHub\Football-League-Table\Source\App_Data\aspnet-FootballLeagueTable-20140927072622.mdf;Initial Catalog=aspnet-FootballLeagueTable-20140927072622;Integrated Security=True");
            //string filepath = "C:\\params.csv";
            //StreamReader sr = new StreamReader(filepath);
            //string line = sr.ReadLine();
            //string[] value = line.Split(',');
            //DataTable dt = new DataTable();
            //DataRow row;
            //foreach (string dc in value)
            //{
            //    dt.Columns.Add(new DataColumn(dc));
            //}

            //while (!sr.EndOfStream)
            //{
            //    value = sr.ReadLine().Split(',');
            //    if (value.Length == dt.Columns.Count)
            //    {
            //        row = dt.NewRow();
            //        row.ItemArray = value;
            //        dt.Rows.Add(row);
            //    }
            //}
            //SqlBulkCopy bc = new SqlBulkCopy(con.ConnectionString, SqlBulkCopyOptions.TableLock);
            //bc.DestinationTableName = "tblparam_test";
            //bc.BatchSize = dt.Rows.Count;
            //con.Open();
            //bc.WriteToServer(dt);
            //bc.Close();
            //con.Close();
        }
    }
}
