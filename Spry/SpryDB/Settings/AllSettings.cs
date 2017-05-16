using Config.Net;
using System;

namespace SpryDB.Settings
{
    public class AllSettings : SettingsContainer
    {
        
        public readonly Option<string> ServerType;
        public readonly Option<string> WorkingDirectory;
        public readonly Option<string> ConnectionString;

    
        protected override void OnConfigure(IConfigConfiguration configuration)
        {            
            configuration.UseJsonFile(string.Format(@"{0}\config.json", AppDomain.CurrentDomain.BaseDirectory));
        }
    }
}
