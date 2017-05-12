using CommandLine;

namespace SpryDB.Options
{
    [Verb("Baseline", HelpText = "Baselines an existing database at the baselineVersion.")]
    class BaselineOptions
    {


        public int RunBaselineReturnExitCode(BaselineOptions opts)
        {
            return 0;
        }
    }

  

}
