using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpryDB.Models
{
    class settings
    {

        public enum ServerTypes { MSSQL, MYSQL, ORACLE };

        private ServerTypes _server;

        public ServerTypes Server
        {
            get { return _server; }
            set { _server = value; }
        }

        public string ConnectionString { get; set; }

        public string WorkingDirectory { get; set; }


    }
}
