using CommandLine;
using ConsoleTables;
using SpryDB.Settings;
using System;
using System.IO;
using System.Security.AccessControl;
using System.Security.Principal;

namespace SpryDB.Options
{
    [Verb("info", HelpText = "Prints the information about applied, current and pending migrations.")]
    class InfoOptions
    {
        public int RunInfoAndReturnExitCode()
        {
            var config = new AllSettings();

            if (Utils.TestConfigtation())
            {
                if (Utils.IsAnyPendigFile())
                {
                    string rootPath = config.WorkingDirectory;

                    string[] dirs = Directory.GetDirectories(rootPath);

                    foreach (var folder in dirs)
                    {
                        string[] files = Directory.GetFiles(folder, "*.sql", SearchOption.AllDirectories);
                        Console.WriteLine("");
                        var table = new ConsoleTable("Group", "File Name", "State", "Owner");
                        foreach (string file in files)
                        {
                            string filename = Path.GetFileNameWithoutExtension(file);

                            FileInfo fileInfo = new FileInfo(file);
                            FileSecurity fileSecurity = fileInfo.GetAccessControl();
                            IdentityReference identityReference = fileSecurity.GetOwner(typeof(NTAccount));


                            var directoryInfo = new DirectoryInfo(file).Parent;
                            if (directoryInfo != null)
                            {
                                string result = directoryInfo.Name;
                                table.AddRow(result, filename, "pending", identityReference.Value);
                            }
                        }
                        table.Write();
                    }
                }
                else
                {                    
                    Console.WriteLine(string.Concat("Pending file not found in working directory: ", config.WorkingDirectory));                    
                }
            }             
            else
            {
                Console.WriteLine("Configration is missing...");
                Utils.DisplayConfigration();
            }

            return 0;
        }

    }
}
