using CommandLine;

namespace SpryDB.Options
{
    [Verb("Clean", HelpText = "Drops all objects in the configured schemas.")]
    class CleanOptions
    {
        public int RunCleanAndReturnExitCode(CleanOptions opts)
        {
            return 0;
        }
    }
}
