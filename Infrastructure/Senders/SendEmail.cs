using System.Net.Mail;

namespace Infrastructure.Senders
{
    public class SendEmail
    {
        public static void Send(string to,string subject,string body)
        {
            using (MailMessage mail = new MailMessage())
            {
                mail.From = new MailAddress("EMLearn1400@gmail.com", "ای ام لرن");
                mail.To.Add(to);
                mail.Subject = subject;
                mail.Body = body;
                mail.IsBodyHtml = true;
                //mail.Attachments.Add(new Attachment("c:/textfile.txt"));
                using (SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com", 587))
                {
                    SmtpServer.UseDefaultCredentials = false;
                    SmtpServer.Credentials = new System.Net.NetworkCredential("EMLearn1400@gmail.com", "Merati1400");
                    SmtpServer.EnableSsl = true;
                    SmtpServer.Send(mail);
                }

            }
        }
    }
}