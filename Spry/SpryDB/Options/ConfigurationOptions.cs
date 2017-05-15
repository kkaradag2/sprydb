using System;
using CommandLine;
using CommandLine.Text;
using System.Reflection;

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
            Console.ForegroundColor = ConsoleColor.DarkGreen;

            Console.WriteLine("Pleace select your database server type:");
            Console.WriteLine("");
            Console.WriteLine("1. MS-SQL Server");
            Console.WriteLine("2. MYSQL");
            Console.WriteLine("3. ORACLE");
            Console.WriteLine("4. Exit configuration");
            Console.ResetColor();



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
