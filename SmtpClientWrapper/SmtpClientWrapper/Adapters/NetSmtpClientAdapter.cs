using SmtpClientWrapper.Adaptees;
using SmtpClientWrapper.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace SmtpClientWrapper.Adapters
{
    public class NetSmtpClientAdapter : NetSmtpClientAdaptee, ISmtpClientAdapter
    {
        public string Host { get; set; }

        public int Port { get; set; }
        public int Timeout { get; set; }

        public bool UseDefaultCredentials { get; set; }
        public bool EnableSsl { get; set; }

        public NetSmtpClientAdapter(string host, int port) : base(host, port) { }
        public NetSmtpClientAdapter(string host, int port, string username, string password) : base(host, port, username, password) { }

        public void SendAsync(MailMessage message)
        {
            Task.Factory.StartNew(() => Send(message));
        }

        public void SendAsync(IEmail email)
        {
            Task.Factory.StartNew(() => Send(email));
        }

        public void SendAsync(string from, string to, string subject, string body)
        {
            Task.Factory.StartNew(() => Send(from, to, subject, body));
        }
    }
}
