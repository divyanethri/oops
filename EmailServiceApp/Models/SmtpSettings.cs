namespace EmailServiceApp.Models
{
    public class SmtpSettings
    {
        public string SmtpServer { get; set; }
        public int Port { get; set; }
        public bool EnableSsl { get; set; }
        public string senderEmail { get; set; }
        public string senderPassword { get; set; }
    }
}
