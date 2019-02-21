using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using server.Models;
using CuentasClaras.Services;
using CuentasClaras.Models;

namespace CuentasClaras.Controllers
{
    [Route("api/Mail")]
    [Produces("application/json")]
    public class MailController : Controller
    {
        private readonly MailService mailService;

        public MailController(MailService mailService)
        {
            this.mailService = mailService;
        }

        [Route("contact")]
        public ContentResult sendEmail([FromBody]EmailDTO contact)
        {
            mailService.sendEmail(contact.name, contact.email, contact.msg);

            return new ContentResult
            {
                StatusCode = (int)HttpStatusCode.OK,
                Content = {}
            };
        }

    }
}