using MailSender.Models;

namespace MailSender.Service
{
    public interface IEmailSender
    {
        Task<EmailResponse> SendEmailAsync(EmailConfig data);
    }
}
