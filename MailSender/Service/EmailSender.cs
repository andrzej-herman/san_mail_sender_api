using FluentEmail.Core;
using FluentEmail.Smtp;
using MailSender.Models;
using System.Net;
using System.Net.Mail;
using FluentEmail.Core.Models;

namespace MailSender.Service
{
    public class EmailSender : IEmailSender
    {
        private readonly IConfiguration _config;

        public EmailSender(IConfiguration config)
        {
            _config = config;
        }

        public async Task<EmailResponse> SendEmailAsync(EmailConfig data)
        {
            try
            {
                var sender = new SmtpSender(() => new SmtpClient()
                {
                    Host = _config.GetValue<string>("SmtpSettings:Host"),
                    Port = _config.GetValue<int>("SmtpSettings:Port"),
                    EnableSsl = false,
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    Credentials = new NetworkCredential(_config.GetValue<string>("SmtpSettings:UserName"), _config.GetValue<string>("SmtpSettings:Pwd"))
                });

                Email.DefaultSender = sender;
                var subject = data.Subject;
                var body = $"<h4>Witaj {data.FirstName}</h4><br/><p>To jest email wysłany poprzez nasze API do wysyłania maili.</p>";
                var addresses = new List<Address>();
                addresses.AddRange(data.EmailAddresses.Select(a => new Address(a)));

                var email = await Email
                    .From("mail@aherman.org")
                    .To(addresses)
                    .Subject(subject)
                    .Body(body, data.IsHtml)
                    .SendAsync();

                return new EmailResponse 
                {
                    Result = true,
                    Id = Guid.NewGuid(),
                };
            }
            catch (Exception ex)
            {
                return new EmailResponse { Result = false, Error = ex.Message };
            }
        }
    }
}
