using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Mail;

namespace SmtpClientWrapper.Adapter
{
    // Target of Adapter pattern:
    public interface ISmtpClient
    {
        string Host { get; set; }

        int Port { get; set; }
        int Timeout { get; set; }

        bool UseDefaultCredentials { get; set; }
        bool EnableSsl { get; set; }

        void Send(MailMessage message);
        void Send(string from, string to, string subject, string body);
    }
}
