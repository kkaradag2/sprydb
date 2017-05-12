using CommandLine;

namespace SpryDB.Options
{
    [Verb("Migrate", HelpText = "Migrates the database.")]
    class MigrateOptions
    {
        public int RunMigrateAndReturnExitCode(MigrateOptions opts)
        {
            return 0;
        }
    }
}
