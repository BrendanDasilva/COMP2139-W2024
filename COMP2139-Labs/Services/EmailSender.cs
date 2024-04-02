using Microsoft.AspNetCore.Identity.UI.Services;
using SendGrid;
using SendGrid.Helpers.Mail;
using System.Threading.Tasks;

namespace COMP2139_Labs.Services
{
  public class EmailSender : IEmailSender
  {
    private readonly string _sendGridKey;

    public EmailSender(IConfiguration configuration)
    {
      _sendGridKey = configuration["SendGrid:ApiKey"];
    }

    public async Task SendEmailAsync(string email, string subject, string message)
    {
      var client = new SendGridClient(_sendGridKey);
      var from = new EmailAddress("101447806@georgebrown.ca", "Project Management App");
      var to = new EmailAddress(email);
      var plainTextContent = "";
      var htmlContent = message;
      var msg = MailHelper.CreateSingleEmail(from, to, subject, plainTextContent, htmlContent);
      await client.SendEmailAsync(msg);
    }
  }
}
