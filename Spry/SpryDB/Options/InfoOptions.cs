using CommandLine;

namespace SpryDB.Options
{
    [Verb("Info", HelpText = "Prints the information about applied, current and pending migrations.")]
    class InfoOptions
    {
        public int RunInfoAndReturnExitCode(InfoOptions opts)
        {
            return 0;
        }
    }
}
