using System;
using CommandLine;
using CommandLine.Text;
using System.Reflection;
using System.Drawing;
using Console = Colorful.Console;
using System.Text.RegularExpressions;
using SpryDB.Models;

namespace SpryDB.Options
{
    [Verb("Configuration", HelpText = "Clone a repository into a new directory.")]
    class ConfigurationOptions
    {

        [Option('s', "set-config", HelpText = "Set new configration. if you already have, this comment overwrite it.")]
        public bool setConfig { get; set; }

        [Option('l', "list-config", HelpText = "Display your current configration.")]
        public bool listConfig { get; set; }

        [Option('t', "test-config", HelpText = "Test your current configration.")]
        public bool testConfig { get; set; }

        public int RunConfigurationAndReturnExitCode()
        {
            
            if (this.setConfig)
                SaveNewConfigration();

            if (this.listConfig)
                ListConfigration();

            if (this.testConfig)
                TestConfigration();

            if(isNoArgument()) // Run help if no argument is input for configuration command.
                Parser.Default.ParseArguments<ConfigurationOptions>(new string[] { "verb", "--help" });


            return 0;
        }

        private void TestConfigration()
        {
            Console.WriteLine("Test configration");            
        }

        private void ListConfigration()
        {
            Console.WriteLine("List configration");
        }

        private void SaveNewConfigration()
        {
            var setting = new settings();

            Console.WriteLine("");
            Console.WriteLine("Pleace select your database server:",Color.White);
            Console.WriteLine("");
            Console.WriteLine("[1] MS SQL server", Color.White);
            Console.WriteLine("[2] ORACLE server", Color.White);
            Console.WriteLine("[3] MYSQL server", Color.White);
            Console.WriteLine("[0] Exit", Color.White);
            Console.WriteLine("");
            Console.WriteLine("------------------------------------",Color.White);
            Console.Write("Please enter a value between 0 and 3: ", Color.DarkGreen);

            Regex regexMenu = new Regex(@"([0-4])");            
            string menu = Console.ReadLine();
            
            while (!regexMenu.IsMatch(menu))
            {
                Console.WriteLine("Bad input", Color.Red);
                Console.Write("Please enter a value between 0 and 3: ", Color.DarkGreen);
                menu = Console.ReadLine();
            }





            Regex folder = new Regex(@"^(?:[a-zA-Z]\:|\\\\[\w\.]+\\[\w.$]+)\\(?:[\w]+\\)*\w([\w.])+$");  // Folder regex  c:\sql\working
            Regex share = new Regex(@"^(\\)(\\[A-Za-z0-9-_]+){2,}(\\?)$");
          
            




            string connectionstring = string.Empty;
            string workingdirectory = string.Empty;

            //try
            //{
                
            //    opcao = int.Parse(Console.ReadLine());
            //    switch (opcao)
            //    {
            //        case 1:     // MS SQL Server
            //            setting.Server = settings.ServerTypes.MSSQL;
            //            break;
            //        case 2:     // ORACLE Server
            //            setting.Server = settings.ServerTypes.ORACLE;
            //            break;
            //        case 3:     // MYSQL Server
            //            setting.Server = settings.ServerTypes.MYSQL;
            //            break;
            //        case 0:
            //            Environment.Exit(0);
            //            break;
            //        default:
            //            throw new Exception("Pleace select 0-3 arange");
            //            break;
            //    }

            //    Regex folder = new Regex(@"^(?:[a-zA-Z]\:|\\\\[\w\.]+\\[\w.$]+)\\(?:[\w]+\\)*\w([\w.])+$");  // Folder regex  c:\sql\working
            //    Regex share = new Regex(@"^(\\)(\\[A-Za-z0-9-_]+){2,}(\\?)$");

             
            //}
            //catch (Exception exp)
            //{
            //    Console.WriteLine(exp.Message, Color.Red);
            //    Console.WriteLine("-------------------------------------", Color.White);
            //    SaveNewConfigration();
            //}
            
        }
        

        private bool isNoArgument()
        {           

            foreach (PropertyInfo pi in this.GetType().GetProperties())
            {
                bool value = (bool)pi.GetValue(this);
                if (value)
                    return false;
            }
                return true;
        }
        
      

    }
}

