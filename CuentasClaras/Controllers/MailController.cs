using CuentasClaras.Api.Mail;
using CuentasClaras.Services;
using Microsoft.AspNetCore.Mvc;
using System.Net;

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
                Content = { }
            };
        }

        [HttpGet]
        [Route("")]
        public object test()
        {
            var config = mailService.GetConfig();

            return new
            {
                config.User
            };
        }
    }

}