using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmtpClientWrapper.Adapter
{
    public class Email : IEmail
    {
        public string To { get; set; } // Recipient
        public string From { get; set; } // Sender
        public string Subject { get; set; }
        public string Body { get; set; }

        public Email() { }

        public Email(string to, string from, string subject, string body)
        {
            this.To = to;
            this.From = from;
            this.Subject = subject;
            this.Body = body;
        }
    }
}
