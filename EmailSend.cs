using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.Mail;
using System.Diagnostics;
namespace MultiFaceRec
{
    public class EmailSend
    {
        static Stopwatch stTime = new Stopwatch();
        public static void SendMail(string emailTo, string subject,string body,string attachmentPath)
        {
            if (!stTime.IsRunning || stTime.Elapsed.TotalMilliseconds > 10000 || subject.Contains("Alarm"))
            {
                string emailFrom = "YourMailId@gmail.com";
                string password = "your gmail password";
                string smtpAddress = "smtp.gmail.com";
                int portNumber = 587;
                bool enableSSL = true;

                using (MailMessage mail = new MailMessage())
                {
                    mail.From = new MailAddress(emailFrom);
                    mail.To.Add(emailTo);
                    mail.Subject = subject;
                    mail.Body = body;
                    mail.IsBodyHtml = true;
                    // Can set to false, if you are sending pure text.
                    if (attachmentPath.Length > 2)
                    {
                        mail.Attachments.Add(new Attachment(attachmentPath));
                    }

                    using (SmtpClient smtp = new SmtpClient(smtpAddress, portNumber))
                    {
                        smtp.Credentials = new NetworkCredential(emailFrom, password);
                        smtp.EnableSsl = enableSSL;
                        smtp.Send(mail);
                    }
                }
                if (!stTime.IsRunning)
                {
                    stTime.Start();
                }
                else
                {
                    stTime.Reset();
                    stTime.Restart();
                }
            }
        }
    }
}
