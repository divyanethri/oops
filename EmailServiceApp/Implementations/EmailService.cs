using EmailServiceApp.Contracts;
using EmailServiceApp.Models;
using System.Net;
using System.Net.Mail;

namespace EmailServiceApp.Services
{
    public class EmailService : IEmailService
    {
        private SmtpClient _smtpClient;

        public EmailService ( SmtpSettings smtpSettings )
        {
            _smtpClient = new SmtpClient(smtpSettings.SmtpServer , smtpSettings.Port);
            _smtpClient.EnableSsl = smtpSettings.EnableSsl;
            _smtpClient.Credentials = new NetworkCredential(smtpSettings.senderEmail , smtpSettings.senderPassword);
        }

        public async Task SendEmail ( Email email )
        {
            try
            {
                var mailMessage = new MailMessage();
                mailMessage.From = new MailAddress(email.Sender);
                mailMessage.To.Add(email.Recipients);
                mailMessage.Subject = email.Subject;
                mailMessage.Body = email.Body;
                await _smtpClient.SendMailAsync(mailMessage);
            }
            catch ( Exception ex )
            {
                Console.WriteLine(ex.Message);
            }
        }

        public async Task SendBatchEmailsAsync ()
        {
            List<string> recipientEmails = new List<string>();
            Console.WriteLine("Enter emails:");
            string input = Console.ReadLine();
            string[] emails = input.Split(new char[] { ' ' , '\t' , '\n' , '\r' } , StringSplitOptions.RemoveEmptyEntries);

            foreach ( string email in emails )
            {
                recipientEmails.Add(email);
            }

            foreach ( string recipient in recipientEmails )
            {
                var email = new Email
                {
                    Sender = "divyanethrik@gmail.com" ,
                    Recipients = recipient ,
                    Subject = "Multiple emails" ,
                    Body = "Check check check?"
                };
                try
                {
                    await SendEmail(email);
                }
                catch ( Exception ex )
                {
                    Console.WriteLine(ex.Message);
                }
            }
            Console.WriteLine("Emails sent successfully.");
        }
    }
}
