using CommandLine;

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
            return 0;
        }
    }
}
