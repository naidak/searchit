using Twilio;
using Twilio.Rest.Api.V2010.Account;
using Microsoft.Extensions.Configuration;
using Twilio.Types;

namespace JobSearchingWebApp.Helper.Services
{
    public class SmsService
    {
        private readonly IConfiguration configuration;
        private readonly string AccountSID;
        private readonly string AuthToken;
        private readonly string FromNumber;

        public SmsService(IConfiguration configuration)
        {
            this.configuration = configuration;
            this.AccountSID = configuration["SMSSettings:AccountSID"];
            this.AuthToken = configuration["SMSSettings:AuthToken"];
            this.FromNumber = configuration["SMSSettings:FromNumber"];
        }

        public Task<bool> SendSmsAsync(string to, string message)
        {
            try
            {
                TwilioClient.Init(AccountSID, AuthToken);

                var messageOptions = new CreateMessageOptions(new PhoneNumber(to))
                {
                    From = new PhoneNumber(FromNumber),
                    Body = message
                };

                var msg = MessageResource.Create(messageOptions);
    
                return Task.FromResult(true);
            }
            catch (Exception ex)
            {
                return Task.FromResult(false);
            }
        }
    }
}
