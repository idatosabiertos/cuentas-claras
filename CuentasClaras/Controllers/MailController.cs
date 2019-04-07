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
using CuentasClaras.Api.Mail;
using CuentasClaras.Services;

namespace CuentasClaras.Controllers
{
    [Route("api/mail")]
    [ApiController]
    public class MailController : ControllerBase
    {
        private readonly MailService mailService;

        public MailController(MailService mailService)
        {
            this.mailService = mailService;
        }
       
        [HttpPost]
        [Route("contact")]
        public ContentResult sendEmail([FromBody]EmailDTO contact)
        {
            mailService.sendEmail(contact.Name, contact.Email, contact.Msg);

            return new ContentResult
            {
                StatusCode = (int)HttpStatusCode.OK,
                Content = {}
            };
        }

    }
}