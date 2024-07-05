namespace EmailServiceApp.Models
{
    using System;
    public class Email
    {
        public string Sender { get; set; }
        public string Recipients { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
        public DateTime Timestamp { get; set; }

        public Email ()
        {
            Timestamp = DateTime.Now;
        }
    }
}
