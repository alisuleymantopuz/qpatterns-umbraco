using System.Net.Mail;
using MailMessage = System.Net.Mail.MailMessage;

namespace qPatterns.Core.Email
{
    public class SimpleMailTransferProtocolService : IEmailService
    {        
        public void SendMail(string from, string to, string subject, string body)
        {                        
            MailMessage message = new MailMessage();
            
            message.From = new MailAddress(from);
            message.To.Add(new MailAddress(to));
            message.Subject = subject;
            message.Body = body;
                        
            SmtpClient smtp = new SmtpClient();            

            smtp.Send(message);
        }     
    }
}
