using Microsoft.AspNetCore.Identity.UI.Services;
using SendGrid;
using SendGrid.Helpers.Mail;
using System.Net.Mail;
using System.Net;
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

    public async Task SendEmailAsync(string email, string subject, string htmlMessage)
    {
      var client = new SendGridClient(_sendGridKey);
      var from = new EmailAddress("brendan.dasilva@gmail.com", "Project Management App");
      var to = new EmailAddress(email);

      var msg = MailHelper.CreateSingleEmail(from, to, subject, "", htmlMessage);

      await client.SendEmailAsync(msg);
    }
  }
}

//public async Task SendEmailAsync(string email, string subject, string htmlMessage)
//{
//  var emailSettings = _configuration.GetSection("EmailSettings");
//  var smtpClient = new SmtpClient
//  {
//    Host = emailSettings["SmtpServer"],
//    Port = int.Parse(emailSettings["SmtpPort"]),
//    EnableSsl = true,
//    Credentials = new NetworkCredential(emailSettings["SmtpUsername"], emailSettings["SmtpPassword"])
//  };

//  var mailMessage = new MailMessage
//  {
//    From = new MailAddress("101447806@georgebrown.ca"),
//    Subject = subject,
//    Body = htmlMessage,
//    IsBodyHtml = true,
//  };
//  mailMessage.To.Add(email);
//  await smtpClient.SendMailAsync(mailMessage);
//}
