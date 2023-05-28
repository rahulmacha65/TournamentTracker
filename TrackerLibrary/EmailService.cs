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
        public static void SendEmail(string fromAddress, string to, string subject, string body)
        {
            SendEmail(fromAddress, new List<string> { to }, subject, body, new List<string> { });
        }
        public static void SendEmail(string fromAddress,List<string> to,string subject, string body,List<string> bcc)
        {
            MailMessage mail = new MailMessage();
            mail.Subject = subject;
            mail.Body = body;
            mail.From = new MailAddress(fromAddress, fromAddress.Split('@')[0]);
            foreach(string email in to)
            {
                mail.To.Add(new MailAddress(email));
            }
            foreach(string bccEmail in bcc)
            {
                mail.Bcc.Add(new MailAddress(bccEmail))
;            }
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
