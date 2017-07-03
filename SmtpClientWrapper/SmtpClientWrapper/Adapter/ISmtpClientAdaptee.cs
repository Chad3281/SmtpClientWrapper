using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Mail;

namespace SmtpClientWrapper.Adapter
{
    // Adaptee interface:
    public interface ISmtpClientAdaptee
    {
        void Send(MailMessage message);
        void Send(IEmail email);
        void Send(string from, string to, string subject, string body);
    }
}
