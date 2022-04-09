using Data;
using Data.ConfigurationModels;
using Data.Entities;
using Services.Contracts;
using Services.Mappers;
using Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class EmailServices : IEmailServices
    {
        private EquilibriumDbContext db;
        private OutlookConfigurationModel configuration;

        public EmailServices(OutlookConfigurationModel configuration, EquilibriumDbContext db)
        {
            this.configuration = configuration;
            this.db = db;
        }

        public EmailServiceModel SendEmail(EmailServiceModel email)
        {
            Send(CreateEmailMessage(email));
            return email;
        }

        public EmailServiceModel SendConfirmEmail(EmailServiceModel email)
        {
            string confirmUrl = $"https://equilibriumsocialmedia.herokuapp.com/ConfirmEmail/{email.Id}";
            string confirmation = "Please, confirm your account by clicking on the fowolling url:";

            email.Content = $"{email.Content}\n{confirmation}\n{confirmUrl}";

            return SendEmail(email);
        }

        public EmailServiceModel AddEmailToDatabase(EmailServiceModel email)
        {
            db.Emails.Add(email.ToEmail());

            db.SaveChanges();

            return email;
        }

        public EmailServiceModel GetEmailById(string id)
        {
            EmailServiceModel email = db.Emails
                .FirstOrDefault(e => e.Id == id)
                .ToEmailServiceModel();

            return email;
        }

        public void DeleteEmailById(string id)
        {
            Email email = db.Emails.FirstOrDefault(e => e.Id == id);

            db.Emails.Remove(email);

            db.SaveChanges();
        }

        public void DeleteEmailByUserEmail(string userEmail)
        {
            Email email = db.Emails.FirstOrDefault(e => e.To == userEmail);

            db.Emails.Remove(email);

            db.SaveChanges();
        }

        public void DeleteAllUserEmails(string userId)
        {
            string userEmail = db.Users.FirstOrDefault(u => u.Id == userId).Email;

            List<Email> emailsToRemove = db.Emails
                .Where(e => e.To == userEmail)
                .ToList();

            db.Emails.RemoveRange(emailsToRemove);
            db.SaveChanges();
        }

        private void Send(MailMessage mailMessage)
        {
            using (var client = new SmtpClient(configuration.SmtpServer, int.Parse(configuration.Port)))
            {
                try
                {
                    NetworkCredential credential = new NetworkCredential(configuration.UserName, configuration.Password);
                    client.Credentials = credential;
                    client.EnableSsl = true;

                    client.Send(mailMessage);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
                finally
                {
                    client.Dispose();
                }
            }
        }

        private MailMessage CreateEmailMessage(EmailServiceModel email)
        {
            MailMessage emailMessage = new MailMessage();

            emailMessage.From = new MailAddress(configuration.From);
            emailMessage.To.Add(email.To);
            emailMessage.Subject = email.Subject;
            emailMessage.Body = email.Content;

            return emailMessage;
        }
    }
}
