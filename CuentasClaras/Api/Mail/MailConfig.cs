using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CuentasClaras.Api.Mail
{
    public class MailConfig
    {
        public string Server { get; set; }
        public string Port { get; set; }
        public string Password { get; set; }
        public string User { get; set; }
        public List<string> UsersCopy { get; set; }
        public string UserFrom { get; set; }
    }
}