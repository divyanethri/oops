using EmailServiceApp.Contracts;
using EmailServiceApp.Models;
using EmailServiceApp.Services;
using Microsoft.Extensions.DependencyInjection;

namespace EmailServiceApp
{
    class Program
    {
        async static Task Main ( string[] args )
        {

            var serviceProvider = new ServiceCollection()
            .AddSingleton(new SmtpSettings
            {
                SmtpServer = "smtp.gmail.com" ,
                Port = 587 ,
                EnableSsl = true ,
                senderEmail = "divyanethrik@gmail.com" ,
                senderPassword = "hmsamkandodqjhhz"
            })
            .AddTransient<IEmailService , EmailService>()
            .BuildServiceProvider();
            var emailService = serviceProvider.GetService<IEmailService>();
            await emailService!.SendBatchEmailsAsync();
        }
    }
}
