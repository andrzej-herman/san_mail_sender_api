namespace MailSender.Models
{
    public class EmailConfig
    {
        public string FirstName { get; set; } = null!;
        public string Subject { get; set; } = null!;
        public IEnumerable<string> EmailAddresses { get; set; } = null!;
        public string Content { get; set; } = null!;
        public bool IsHtml { get; set; }
    }
}
