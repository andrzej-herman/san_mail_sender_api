using Microsoft.AspNetCore.Components.Web;

namespace MailSender.Models
{
    public class EmailResponse
    {
        public bool Result { get; set; }
        public Guid Id { get; set; }
        public string? Error { get; set; }      
    }
}
