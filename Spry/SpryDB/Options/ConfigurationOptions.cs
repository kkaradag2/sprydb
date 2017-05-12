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

        public int RunConfigurationAndReturnExitCode(ConfigurationOptions opts)
        {
            
            if (opts.setConfig)
                SaveNewConfigration();

            if (opts.listConfig)
                ListConfigration();

            if (opts.testConfig)
                TestConfigration();

            if(isNoArgument(opts))
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
            Console.WriteLine("New configration");
           
        }

        private bool isNoArgument(ConfigurationOptions opts)
        {

            foreach (PropertyInfo pi in opts.GetType().GetProperties())
            {
                bool value = (bool)pi.GetValue(opts);
                if (value)
                    return false;
            }
                return true;
        }
        
      

    }
}
