using Mailjet.Client.TransactionalEmails;
using Mailjet.Client;
using JobSearchingWebApp.ViewModels;

namespace JobSearchingWebApp.Helper.Services
{
    public class EmailService
    {
        private readonly IConfiguration config;

        public EmailService(IConfiguration config)
        {
            this.config = config;
        }

        public async Task<bool> SendEmailAsync(EmailSend emailSend)
        {
            MailjetClient client = new MailjetClient(config["MailJet:ApiKey"], config["MailJet:SecretKey"]);

            var email = new TransactionalEmailBuilder()
                 .WithFrom(new SendContact(config["Email:From"], config["Email:ApplicationName"]))
                 .WithSubject(emailSend.Subject)
                 .WithHtmlPart(emailSend.Body)
                 .WithTo(new SendContact(emailSend.To))
                 .Build();

            var response = await client.SendTransactionalEmailAsync(email);
            if (response.Messages != null)
            {
                if (response.Messages[0].Status == "success")
                {
                    return true;
                }
            }

            return false;
        }
    }
}
