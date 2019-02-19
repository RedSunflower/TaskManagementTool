using System;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using System.Net.Mail;
using System.Configuration;
using System.Web;
using System.Net.Mime;

namespace ManagementTool.Roles
{
    public class EmailService : IIdentityMessageService
    {
        public Task SendAsync(IdentityMessage message)
        {
            return Task.Factory.StartNew(() =>
            {
                sendMail(message);
            });
        }
        void sendMail(IdentityMessage message)
        {
            #region formatter
            string text = string.Format("Please click on this link to {0}: {1}", message.Subject, message.Body);
            string html = "Please confirm your account by clicking this link: <a href=\"" + message.Body + "\">link</a><br/>";

            html += HttpUtility.HtmlEncode(@"Or click on the copy the following link on the browser:" + message.Body);
            #endregion
            MailMessage msg = new MailMessage();
            msg.From = new MailAddress(ConfigurationManager.AppSettings["Email"].ToString());
            msg.To.Add(new MailAddress(message.Destination));
            msg.Subject = message.Subject;
            if(msg.Subject != "You were assigned to task ")
            {
                msg.AlternateViews.Add(AlternateView.CreateAlternateViewFromString(text, null, MediaTypeNames.Text.Plain));
                msg.AlternateViews.Add(AlternateView.CreateAlternateViewFromString(html, null, MediaTypeNames.Text.Html));
            }
            msg.Body = message.Body;
            try
            {
                SmtpClient smtpClient = new SmtpClient
                {
                    Host = "smtp.gmail.com",
                    Port = 587,
                    Credentials = new System.Net.NetworkCredential(ConfigurationManager.AppSettings["Email"].ToString(),
                                                                  ConfigurationManager.AppSettings["Password"].ToString()),
                    EnableSsl = true
                };
                smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
                smtpClient.Send(msg);
            } catch(Exception e)
            {
                throw new Exception(e.Message,e.InnerException);
            }


        }
    }
}
