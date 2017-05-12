using CommandLine;

namespace SpryDB.Options
{
    [Verb("Repair", HelpText = "Repairs the metadata table.")]
    class RepairOptions
    {
        public int RunRepairAndReturnExitCode(RepairOptions opts)
        {
            return 0;
        }
    }
}
