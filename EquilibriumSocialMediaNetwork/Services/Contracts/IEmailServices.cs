using Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Contracts
{
    public interface IEmailServices
    {
        EmailServiceModel SendEmail(EmailServiceModel email);

        EmailServiceModel SendConfirmEmail(EmailServiceModel email);

        EmailServiceModel AddEmailToDatabase(EmailServiceModel email);

        EmailServiceModel GetEmailById(string id);

        void DeleteEmailById(string id);

        void DeleteEmailByUserEmail(string userEmail);

        void DeleteAllUserEmails(string userId);
    }
}
