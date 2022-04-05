using Data.Entities;
using Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Mappers
{
    public static class EmailServiceModelMapper
    {
        public static Email ToEmail(this EmailServiceModel email)
        {
            Email result = new Email()
            {
                Id = email.Id,
                To = email.To,
                Subject = email.Subject,
                Content = email.Content
            };

            return result;
        }

        public static EmailServiceModel ToEmailServiceModel(this Email email)
        {
            EmailServiceModel result = new EmailServiceModel()
            {
                Id = email.Id,
                To = email.To,
                Subject = email.Subject,
                Content = email.Content
            };

            return result;
        }
    }
}
