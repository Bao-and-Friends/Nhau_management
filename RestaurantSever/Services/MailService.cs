using RestaurantSever.DAO;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Mail;
using System.Text;

namespace RestaurantSever.Services
{
    public class MailService
    {
        private static readonly Lazy<MailService> Mail = new(() => new MailService());
        public static MailService Instance => Mail.Value;
        private MailService() { }

        private string BEmail = "totribao17891@gmail.com";
        private string AppPassword = "kkwg ihms csfb qyok";

        public MailMessage? CreateMail(string to,string subject,string body)
        {
            try
            {
                MailMessage mail = new();

                mail.From = new MailAddress(BEmail, "The Gourmet Restaurant");

                mail.To.Add(to);

                mail.Subject = subject;
                mail.SubjectEncoding = Encoding.UTF8;

                mail.Body = body;
                mail.IsBodyHtml = true;
                mail.BodyEncoding = Encoding.UTF8;

                return mail;
            }
            catch
            {
                return null;
            }
        }
        public bool Send(MailMessage mail)
        {
            try
            {
                using SmtpClient sender = new("smtp.gmail.com");
                sender.Port = 587;
                sender.EnableSsl = true;
                sender.Credentials = new NetworkCredential(BEmail, AppPassword);
                sender.Send(mail);
                return true;
            }
            catch(Exception)
            {
                return false;
            }
        }
    }
}
