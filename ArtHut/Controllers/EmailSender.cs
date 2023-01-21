using System.Net.Mail;
using System.Net;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Identity.UI.Services;

namespace ArtHut.Controllers
{
    public class EmailSender : IEmailSender
    {
        public async Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            //var client = new SmtpClient("smtp.mailtrap.io", 2525)
            //{
            //    Credentials = new NetworkCredential("9c0941fbfd2382", "40ed75ce310914"),
            //    EnableSsl = true
            //};
            //MailMessage mailMessage = new MailMessage("from@example.com", $"{email}", $"{subject}", $"{htmlMessage}");
            //mailMessage.IsBodyHtml = true;
            //client.Send(mailMessage);
        }


    }
}
