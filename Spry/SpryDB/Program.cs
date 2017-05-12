using System;
using CommandLine;
using SpryDB.Options;

namespace SpryDB
{
    class Program
    {
        static void Main(string[] args)
        {
            Parser.Default.ParseArguments<BaselineOptions, CleanOptions, ConfigurationOptions, InfoOptions, MigrateOptions, RepairOptions, ValidateOptions>(args)
           .MapResult(
               (BaselineOptions      opts) => opts.RunBaselineReturnExitCode(opts),
               (CleanOptions         opts) => opts.RunCleanAndReturnExitCode(opts),
               (ConfigurationOptions opts) => opts.RunConfigurationAndReturnExitCode(opts),
               (InfoOptions          opts) => opts.RunInfoAndReturnExitCode(opts),
               (MigrateOptions       opts) => opts.RunMigrateAndReturnExitCode(opts),
               (RepairOptions        opts) => opts.RunRepairAndReturnExitCode(opts),
               (ValidateOptions      opts) => opts.RunValidateAndReturnExitCode(opts),
           errs => 1);

        }

        

    }
}
