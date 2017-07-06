using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace SmtpClientWrapper.Adapter
{
    // Adapter/Wrapper:
    public class SmtpClientAdapter : ISmtpClient
    {
        private ISmtpClientAdaptee client;

        public string Host { get; set; }

        public int Port { get; set; }
        public int Timeout { get; set; }

        public bool UseDefaultCredentials { get; set; }
        public bool EnableSsl { get; set; }

        public SmtpClientAdapter(ISmtpClientAdaptee client)
        {
            this.client = client;
        }

        public SmtpClientAdapter(ISmtpClientAdaptee client, string host) : this(client)
        {
            this.Host = host;
        }

        public SmtpClientAdapter(ISmtpClientAdaptee client, string host, int port) : this(client, host)
        {
            this.Port = port;
        }

        public void Send(MailMessage message)
        {
            client.Send(message);
        }

        public void Send(IEmail email)
        {
            client.Send(email.From, email.To, email.Subject, email.Body);
        }

        public void Send(string from, string to, string subject, string body)
        {
            client.Send(from, to, subject, body);
        }

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
