using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace TuHaoQuNa.Core.Utility
{
    public sealed class MailHelper
    {
        private MailHelper() { }


        private static void SendEmail(string clientHost, string emailAddress, string receiveAddress,
          string userName, string password, string subject, string body)
        {
            MailMessage mail = new MailMessage();
            mail.From = new MailAddress(emailAddress);
            mail.To.Add(new MailAddress(receiveAddress));
            mail.Subject = subject;
            mail.Body = body;
            mail.IsBodyHtml = true;
            mail.DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure;

            SmtpClient client = new SmtpClient();
            client.Host = clientHost;
            client.Credentials = new NetworkCredential(userName, password);
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            try
            {
                client.SendAsync(mail, null);
            }
            catch (Exception)
            {

            }
        }
    }
}
