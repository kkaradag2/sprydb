using System;
using CommandLine;
using System.Reflection;
using System.Drawing;
using Console = Colorful.Console;
using System.Text.RegularExpressions;
using static SpryDB.Models.settings;
using SpryDB.Settings;
using System.Linq;

namespace SpryDB.Options
{
    [Verb("Config", HelpText = "Used to organize, list and test the configuration data.")]
    class ConfigurationOptions
    {

        [Option('s', "server", HelpText = "It only accepts MSSQL, ORACLE and MYSQL words. Default value is MSSQL")]
        public string serverType { get; set; }

        [Option('c', "connection", HelpText = "Used to define a ConnectionString for the database you will work with")]
        public string connectionString { get; set; }

        [Option('w', "directory", HelpText = "This key is used to define the directory or shared folder you want to work on")]
        public string workingDirectory { get; set; }

        [Option('l', "list-config", HelpText = "Display your current configration.")]
        public bool listConfig { get; set; }

        [Option('t', "test-config", HelpText = "Test your current configration.")]
        public bool testConfig { get; set; }

        public int RunConfigurationAndReturnExitCode()
        {

            var config = new AllSettings();

            // Section of Defination Server Type
            // SAMPLE : Config -s ORACLE
            // SAMPLE : Config -s MYSQL
            if (!string.IsNullOrEmpty(serverType))
            { 
                if (Enum.IsDefined(typeof(ServerTypes), serverType))
                {
                    config.ServerType.Write(serverType);
                }else
                {
                    Parser.Default.ParseArguments<ConfigurationOptions>(new string[] { "verb", "--help" });
                }
            }

            // Section of Defination Database connection: 
            // SAMPLE : Config -c Server=myServerAddress;Database=myDataBase;Trusted_Connection=True;
            if (!string.IsNullOrEmpty(connectionString))
            {
                config.ConnectionString.Write(connectionString);
            }

            // Section of defination working directory
            // SAMPLE : Config -w c:\test\sql
            // SAMPLE : Config -w \\FileServer\SQL\Deployments\
            if(!string.IsNullOrEmpty(workingDirectory))
            {
                Regex folder = new Regex(@"^(?:[a-zA-Z]\:|\\\\[\w\.]+\\[\w.$]+)\\(?:[\w]+\\)*\w([\w.])+$");  // Folder regex  c:\sql\working
                Regex share = new Regex(@"^(\\)(\\[A-Za-z0-9-_]+){2,}(\\?)$");

                Match machFolder = folder.Match(workingDirectory);
                Match machShare = share.Match(workingDirectory);

                if (machFolder.Success || machShare.Success)
                {
                    config.WorkingDirectory.Write(workingDirectory);
                }else
                {
                    Console.WriteLine("Pleace enter path or shared folder.", Color.Red);
                    Parser.Default.ParseArguments<ConfigurationOptions>(new string[] { "verb", "--help" });
                }                    

            }

            // Display curreten configurations
            // SAMPLE :  Config -l
            if(listConfig)
            {
                Utils.DisplayConfigration();                
            }

            // Test curreten configurations. Check database connection is working, Check working directory is accessible.
            // SAMPLE :  Config -t
            if (testConfig)
            {
                Utils.DisplayConfigurationTest();
            }

            if (isAllPropertiesEmpty())
                Parser.Default.ParseArguments<ConfigurationOptions>(new string[] { "verb", "--help" });

            return 0;
        }


        public bool isAllPropertiesEmpty()
        {
            PropertyInfo[] properties = this.GetType().GetProperties();
            int nullCount = 0;
            
            foreach (var pi in properties)
            {
                if (pi.PropertyType == typeof(string))         // To find any string propery is null or empty
                {
                    string value = (string)pi.GetValue(this);
                    if (string.IsNullOrEmpty(value)) { nullCount++; }
                }

                if (pi.PropertyType == typeof(bool))        // To find andy bool propery is null or empty
                {
                    bool value = (bool)pi.GetValue(this);
                    if (!value) { nullCount++; }
                }
            }

            if (nullCount == properties.Count())
                return true;

            return false;
        }

      
      
       
      

    }
}

