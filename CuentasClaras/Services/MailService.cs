using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using CuentasClaras.Api.Mail;

namespace CuentasClaras.Services
{
    public class MailService
    {

        private readonly IConfiguration _configuration;

        public MailService(IConfiguration configuration)
        {
            this._configuration = configuration;
        }

        public bool sendEmail(string email, string name, string msg)
        {
            var section = this._configuration.GetSection("MailConfig");
            var mailConfig = section.Get<MailConfig>();

            SmtpClient client = new SmtpClient(mailConfig.Server);
            client.UseDefaultCredentials = false;
            client.Credentials = new NetworkCredential(mailConfig.User, mailConfig.Password);
            client.EnableSsl = true;

            MailMessage mailMessage = new MailMessage();
            mailMessage.From = new MailAddress(mailConfig.User);

            foreach (var item in mailConfig.UsersCopy)
            {
                mailMessage.Bcc.Add(item);
            }

            mailMessage.To.Add(mailConfig.User);
            mailMessage.ReplyToList.Add(email);
            mailMessage.Subject = $"{name} - cuentasclaras.uy | Consulta";
            mailMessage.Body = msg;

            client.Send(mailMessage);
            return true;
        }

        public MailConfig GetConfig() {
            var section = this._configuration.GetSection("MailConfig");
            var mailConfig = section.Get<MailConfig>();
            return mailConfig;
        }
    }
}
