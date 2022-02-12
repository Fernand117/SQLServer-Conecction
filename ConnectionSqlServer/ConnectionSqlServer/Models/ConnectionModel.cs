using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConnectionSqlServer.Models
{
    public class ConnectionModel
    {
        public string host { get; set; }
        public string port { get; set; }
        public string usuario { get; set; }
        public string password { get; set; }
        public string dbname { get; set; }
    }
}
