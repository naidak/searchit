namespace JobSearchingWebApp.ViewModels
{
    public class EmailSend
    {
        public EmailSend(string to, string subject, string body)
        {
            To = to;
            Subject = subject;
            Body = body;
        }

        public string To { get; set; }

        public string Subject { get; set; }

        public string Body { get; set; }
    }
}
