using FluentEmail.Core.Models;
using MailSender.Auth;
using MailSender.Models;
using MailSender.Service;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.CompilerServices;

namespace MailSender.Controllers
{
    [ApiController]
    [ServiceFilter(typeof(ApiKeyAuthFilter))]
    public class MailingController : ControllerBase
    {
        private readonly IEmailSender _sender;

        public MailingController(IEmailSender sender)
        {
            _sender = sender;
        }

        [HttpPost]
        [Route("send")]
        public async Task<IActionResult> SendAsync(EmailConfig data)
        {
            var res = await _sender.SendEmailAsync(data);
            return res.Result ? Ok(res) : BadRequest();
        }
    }
}