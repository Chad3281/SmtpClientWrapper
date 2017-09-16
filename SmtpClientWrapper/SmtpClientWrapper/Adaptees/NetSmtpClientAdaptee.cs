using SmtpClientWrapper.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace SmtpClientWrapper.Adaptees
{
    // Adaptee for .NET's SmtpClient class:
    public class NetSmtpClientAdaptee : ISmtpClientAdaptee
    {
        private SmtpClient client;
        
        public NetSmtpClientAdaptee(string host, int port)
        {
            this.client = new SmtpClient();
            this.client.Host = host;
            this.client.Port = port;
        }

        public NetSmtpClientAdaptee(string host, int port, string username, string password) : this(host, port)
        {
            this.client.EnableSsl = true;
            this.client.UseDefaultCredentials = false;
            this.client.Credentials = new NetworkCredential(username, password);
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
    }
}
