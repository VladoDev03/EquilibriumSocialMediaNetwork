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

        public EmailServiceModel SendMessage(EmailServiceModel email)
        {
            Send(CreateEmailMessage(email));
            return email;
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

            AddToDatabase(email);

            return emailMessage;
        }

        private EmailServiceModel AddToDatabase(EmailServiceModel email)
        {
            db.Emails.Add(email.ToEmail());
            db.SaveChanges();
            return email;
        }
    }
}
