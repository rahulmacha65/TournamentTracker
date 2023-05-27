using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace TrackerLibrary
{
    public class EmailService
    {
        public static void SendEmail(string fromAddress,string to,string subject, string body)
        {
            MailMessage mail = new MailMessage();
            mail.Subject = subject;
            mail.Body = body;
            mail.From = new MailAddress(fromAddress, fromAddress.Split('@')[0]);
            mail.To.Add(new MailAddress(to));
            mail.IsBodyHtml = true;

            SmtpClient client = new SmtpClient("outlook.mail.com");
            client.UseDefaultCredentials = false;
            client.Port = 25;
            client.EnableSsl = false;
            NetworkCredential creds = new NetworkCredential("", "", "");
            client.Credentials = creds;
            client.Send(mail);

        }
    }
}
