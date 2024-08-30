using System.Net;
using System.Net.Mail;
using API.Models;
using API.Services.Interfaces;
using Microsoft.Extensions.Options;

namespace API.Services
{
    public class EmailService:IEmailService
    {
         private readonly SmtpSettings _smtpSettings;

    public EmailService(IOptions<SmtpSettings> smtpSettings)
    {
        _smtpSettings = smtpSettings.Value;
    }

   public async Task SendEmailAsync(string toEmail, string subject, string message)
        {
            if (string.IsNullOrEmpty(toEmail))
                throw new ArgumentNullException(nameof(toEmail), "Recipient email address cannot be null or empty.");

            if (string.IsNullOrEmpty(subject))
                throw new ArgumentNullException(nameof(subject), "Email subject cannot be null or empty.");

            if (string.IsNullOrEmpty(message))
                throw new ArgumentNullException(nameof(message), "Email message cannot be null or empty.");

          

            try
            {
                var mail = new MailMessage()
                {
                    From = new MailAddress(_smtpSettings.SenderEmail, _smtpSettings.SenderName)
                };
                mail.To.Add(new MailAddress(toEmail));
                mail.Subject = subject;
                mail.Body = message;
                mail.IsBodyHtml = false;

                using (var smtp = new SmtpClient(_smtpSettings.Server, _smtpSettings.Port))
                {
                    smtp.Credentials = new NetworkCredential(_smtpSettings.Username, _smtpSettings.Password);
                    smtp.EnableSsl = !_smtpSettings.UseSsl;

                    // Log the configuration before sending
                    Console.WriteLine("Sending email...");
                    await smtp.SendMailAsync(mail);
                    Console.WriteLine("Email sent successfully.");
                }
            }
            catch (SmtpException ex)
            {
                // Log more details
                Console.WriteLine($"SMTP error: {ex.Message}");
                throw new Exception($"SMTP error: {ex.Message}", ex);
            }
            catch (Exception ex)
            {
                // General exception logging
                Console.WriteLine($"General error: {ex.Message}");
                throw new Exception($"General error: {ex.Message}", ex);
            }
        }
    }
}