using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreditRegistration.DbCommon.Models
{
    public class DbConfig
    {
        public string connectionString { get; set; }
        public string schemaName { get; set; }

        public DbConfig() { }
    }
}
