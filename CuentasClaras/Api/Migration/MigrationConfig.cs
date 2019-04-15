using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CuentasClaras.Api.Migration
{
    public class MigrationConfig
    {
        public bool CheckIfExists { get; set; }
        public string DataSource { get; set; }
    }
}
