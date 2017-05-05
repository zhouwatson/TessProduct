using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using WZ.Services.Interfaces;

namespace WZ.Infrastructure.Common.Email
{
    public class SmtpEmailService : Services.Interfaces.IEmailService
    {
        protected readonly IConfigurationService _configurationService;
        protected readonly ILoggingService _loggingService;

        public SmtpEmailService(
            IConfigurationService configurationService,
            ILoggingService loggingService)
        {
            this._configurationService = configurationService;
            this._loggingService = loggingService;
        }


        public bool SendEmail(
            string subject,
            string body,
            string from,
            IEnumerable<string> to,
            IEnumerable<string> cc,
            IEnumerable<string> bcc)
        {
            var message = new System.Net.Mail.MailMessage();

            message.Subject = subject;
            message.Body = body;
            message.IsBodyHtml = true;

            message.From = new System.Net.Mail.MailAddress(from);

            foreach (var email in to)
            {
                message.To.Add(email);
            }

            foreach (var email in cc)
            {
                message.CC.Add(email);
            }

            foreach (var email in bcc)
            {
                message.Bcc.Add(email);
            }

            return SendEmail(message);
        }

        public bool SendEmail(MailMessage message)
        {
            try
            {
                var mailServer = _configurationService.GetValue("MAIL_SERVER", "localhost");
                var port = _configurationService.GetValue("MAIL_SERVER_PORT", 0);
                var username = _configurationService.GetValue("MAIL_SERVER_USERNAME", string.Empty);
                var password = _configurationService.GetValue("MAIL_SERVER_PASSWORD", string.Empty);
                var enableSsl = _configurationService.GetValue("MAIL_SERVER_ENABLE_SSL", false);

                SmtpClient client = new SmtpClient(mailServer);
                if (port > 0)
                {
                    client.Port = port;
                }
                if (!string.IsNullOrEmpty(username) && !string.IsNullOrEmpty(password))
                {
                    client.Credentials = new System.Net.NetworkCredential(username, password);
                }
                if (enableSsl)
                {
                    client.EnableSsl = true;
                }

                client.DeliveryMethod = SmtpDeliveryMethod.Network;
                client.Send(message);
                return true;
            }
            catch (Exception ex)
            {
                _loggingService.LogError(ex);
                return false;
            }
        }


        public bool SendEmail(string subject, string body, string from, string to, string cc, string bcc)
        {
            return SendEmail(
                subject,
                body,
                from,
                to.Split(",".ToCharArray(), StringSplitOptions.RemoveEmptyEntries),
                cc.Split(",".ToCharArray(), StringSplitOptions.RemoveEmptyEntries),
                bcc.Split(",".ToCharArray(), StringSplitOptions.RemoveEmptyEntries)
                );
        }
    }
}
