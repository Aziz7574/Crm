using Crm.Website.Service.EmailService.Interfaces;


namespace Crm.Website.Service.EmailService.Classes
{
    public class EmailSender : IEmailSender
    {
        public Task SendEmail(string email, string subject, string message)
        {
            var mail = "zzrxmnv1002@gmail.com";
            var test = "Hello friend";

            var client = new System.Net.Mail.SmtpClient();
            return null;
        }
    }
}
