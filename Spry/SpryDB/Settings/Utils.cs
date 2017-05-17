using CommandLine;
using ConsoleTables;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpryDB.Settings
{
    public class Utils
    {
        private static AllSettings config = new AllSettings();

        public static string DirectoryExists(string path)
        {
            if (Directory.Exists(path))
                return "Success";
            return "Fails";
        }

 
        public static bool TestConfigtation()
        {
            

            if (string.IsNullOrEmpty(config.ConnectionString))
            {
                return false;
            }
            else
            {
                if (config.ServerType == "MSSQL")
                {
                    try { using (new SqlConnection(config.ConnectionString)) { } }
                    catch (SqlException) { return false; }
                }
            }

            if (!Directory.Exists(config.WorkingDirectory))
                return false;

            return true;
        }

        public static bool IsAnyPendigFile()
        {

            string[] dirs = Directory.GetDirectories(config.WorkingDirectory);

            foreach (var folder in dirs)
            {
                string[] files = Directory.GetFiles(folder, "*.sql", SearchOption.AllDirectories);
                if (files.Length > 0)
                    return true;
                return false;
            }
            return false;
        }

        public static void DisplayConfigration()
        {
            try
            {
                Console.WriteLine("\nCurrent Configuration:\n", Color.DarkGreen);

                var table = new ConsoleTable("Properties", "Values");
                table.AddRow("Database Server", config.ServerType ?? "Not Defined")
                     .AddRow("Connection String", config.ConnectionString ?? "Not Defined")
                     .AddRow("Working Directory", config.WorkingDirectory ?? "Not Defined");
                table.Write();
            }
            catch (Exception)
            {
                Console.WriteLine("Configuration is not defined.", Color.Red);
                Console.WriteLine("You can learn how to define the configuration with the help Config.");
            }
        }

        public static void DisplayConfigurationTest()
        {
            var table = new ConsoleTable("Properties", "Values", "Status");

            if (!string.IsNullOrEmpty(config.ConnectionString))
            {
                if (string.IsNullOrEmpty(config.ServerType))
                {
                    config.ServerType.Write("MSSQL"); // Defaul value is setting.
                }
                table.AddRow("Connection String", config.ConnectionString, CheckConnectionString(config));
                if (Directory.Exists(config.WorkingDirectory))
                {
                    table.AddRow("Working Directory", config.WorkingDirectory ?? "null", "Success");
                }
                else
                {
                    table.AddRow("Working Directory", config.WorkingDirectory ?? "null", "Fail");
                }
            }
            else
            {
                table.AddRow("Connection String", "not defined", "Fail");
            }
            table.Write();
        }

        private static string CheckConnectionString(AllSettings config)
        {
            if (config.ServerType == "MSSQL")
            {
                try { using (new SqlConnection(config.ConnectionString)) { } return "Success"; }
                catch (SqlException ex) { return string.Format("{0} - {1}", "Fail", ex.Message); }
            }
            return "Fail";
        }



    }
}
