using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Mail;
using SmtpClientWrapper.Messages;

namespace SmtpClientWrapper.Adapters
{
    // Target of Adapter pattern:
    public interface ISmtpClientAdapter
    {
        string Host { get; set; }

        int Port { get; set; }
        int Timeout { get; set; }

        bool UseDefaultCredentials { get; set; }
        bool EnableSsl { get; set; }

        void Send(MailMessage message);
        void Send(IEmail email);
        void Send(string from, string to, string subject, string body);

        void SendAsync(MailMessage message);
        void SendAsync(IEmail email);
        void SendAsync(string from, string to, string subject, string body);
    }
}
