using CommandLine;

namespace SpryDB.Options
{
    [Verb("Configuration", HelpText = "Clone a repository into a new directory.")]
    class ConfigurationOptions
    {
        public int RunConfigurationAndReturnExitCode(ConfigurationOptions opts)
        {
            return 0;
        }
    }
}
