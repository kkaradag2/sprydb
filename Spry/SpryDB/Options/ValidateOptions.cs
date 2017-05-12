using CommandLine;

namespace SpryDB.Options
{
    [Verb("Validate", HelpText = "Validates the applied migrations against the ones on the classpath.")]
    class ValidateOptions
    {
        public int RunValidateAndReturnExitCode(ValidateOptions opts)
        {
            return 0;
        }
    }
}
