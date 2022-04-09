using Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Contracts
{
    public interface IMessageServices
    {
        /// <summary>
        /// Gets all messages from the database.
        /// </summary>
        /// <returns>All messages in the database.</returns>
        List<MessageServiceModel> GetAllMessages();

        /// <summary>
        /// Gets a message by its id.
        /// </summary>
        /// <param name="id">Message id.</param>
        /// <returns>The searched message.</returns>
        MessageServiceModel GetMessageById(string id);

        /// <summary>
        /// Adds message to the database.
        /// </summary>
        /// <param name="message">The message to be added.</param>
        /// <returns>The added message.</returns>
        MessageServiceModel AddMessage(MessageServiceModel message);

        /// <summary>
        /// Removes message from the database.
        /// </summary>
        /// <param name="messageId">Id of the message that is going to be removed.</param>
        void RemoveMessage(string messageId);

        /// <summary>
        /// Removes all messages, from the database, ever sent by a given user or sent to a user.
        /// </summary>
        /// <param name="userId">The user that has sent the message or it was sent to.</param>
        void DeleteAllUserMessages(string userId);
    }
}
