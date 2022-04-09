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
        /// <summary>
        /// Sends email to user.
        /// </summary>
        /// <param name="email">The emails address that the email is going to be sent.</param>
        /// <returns>The email that has just been sent.</returns>
        EmailServiceModel SendEmail(EmailServiceModel email);

        /// <summary>
        /// Sends confirmation email to user when new account is created.
        /// </summary>
        /// <param name="email">Email that is going to be sent.</param>
        /// <returns>The email that has just been sent.</returns>
        EmailServiceModel SendConfirmEmail(EmailServiceModel email);

        /// <summary>
        /// Adds sent email to database.
        /// </summary>
        /// <param name="email">The email that is being added to the database.</param>
        /// <returns>The email that has just been sent.</returns>
        EmailServiceModel AddEmailToDatabase(EmailServiceModel email);

        /// <summary>
        /// Gets email by its id.
        /// </summary>
        /// <param name="id">Id of the searched email.</param>
        /// <returns>The searched email if is found.</returns>
        EmailServiceModel GetEmailById(string id);

        /// <summary>
        /// Deletes email by its id.
        /// </summary>
        /// <param name="id">Id of the email that we want to delete.</param>
        void DeleteEmailById(string id);

        /// <summary>
        /// Deletes email by the user it was sent to.
        /// </summary>
        /// <param name="userEmail">User's email.</param>
        void DeleteEmailByUserEmail(string userEmail);

        /// <summary>
        /// Deletes all emails that have ever been sent to the given user.
        /// </summary>
        /// <param name="userId"></param>
        void DeleteAllUserEmails(string userId);
    }
}
