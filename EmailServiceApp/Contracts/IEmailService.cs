using EmailServiceApp.Models;

namespace EmailServiceApp.Contracts
{
    public interface IEmailService
    {
        public Task SendEmail ( Email email );
        Task SendBatchEmailsAsync ();
    }
}
