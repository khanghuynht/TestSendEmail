using System.Net;
using System.Net.Mail;

namespace EmailProject.Service
{
    public interface IEmailService
    {
        void SendEmail(SendEmailModel model);
    }
    public class EmailService : IEmailService
    {
        public EmailService()
        {

        }
        public void SendEmail(SendEmailModel model)
        {
            try
            {
                MailMessage message = new MailMessage()
                {
                    Subject = "[Reset Password] OTP For Reset Password",
                    IsBodyHtml = false,
                    Body = model.Content
                };
                message.From = new MailAddress(EmailSettingModel.Instance.FromEmailAddress, EmailSettingModel.Instance.FromDisplayName);
                message.To.Add(model.ReceiveAddress);

                var smtp = new SmtpClient()
                {
                    EnableSsl = EmailSettingModel.Instance.Smtp.EnableSsl,
                    Host = EmailSettingModel.Instance.Smtp.Host,
                    Port = EmailSettingModel.Instance.Smtp.Port,
                };
                var network = new NetworkCredential(EmailSettingModel.Instance.Smtp.EmailAddress, EmailSettingModel.Instance.Smtp.Password);
                smtp.Credentials = network;
                smtp.Send(message);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
