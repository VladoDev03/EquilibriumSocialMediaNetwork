using Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Contracts
{
    public interface IConversationServices
    {
        /// <summary>
        /// Gets all conversations in the database.
        /// </summary>
        /// <returns>All conversations from the database.</returns>
        List<ConversationServiceModel> GetAllConversations();

        /// <summary>
        /// Gets all conversations of a given user.
        /// </summary>
        /// <param name="userId">Id of the user.</param>
        /// <returns>All conversations of a user.</returns>
        List<ConversationServiceModel> GetUserConversations(string userId);

        /// <summary>
        /// Gets the conversation between two users.
        /// </summary>
        /// <param name="userIdOne">First user id.</param>
        /// <param name="userIdTwo">Second user id.</param>
        /// <returns>Conversation between both users.</returns>
        ConversationServiceModel GetConversationByTwoUserIds(string userIdOne, string userIdTwo);

        /// <summary>
        /// Finds conversation by a given id.
        /// </summary>
        /// <param name="id">Id of the searched conversation.</param>
        /// <returns>The searched conversation.</returns>
        ConversationServiceModel GetConversationById(string id);

        /// <summary>
        /// Adds conversation to the database.
        /// </summary>
        /// <param name="conversation">The conversation that we want to add to the database.</param>
        /// <returns>The added conversation.</returns>
        ConversationServiceModel AddConversation(ConversationServiceModel conversation);

        /// <summary>
        /// Removes a conversation by its id.
        /// </summary>
        /// <param name="conversationId">Id of the conversation we want to remove.</param>
        void RemoveConversation(string conversationId);

        /// <summary>
        /// Removes a conversation by its two users.
        /// </summary>
        /// <param name="userIdOne">Id of the first user.</param>
        /// <param name="userIdTwo">Id of the second user.</param>
        void DeleteConversationByUserIds(string userIdOne, string userIdTwo);

        /// <summary>
        /// Removes all conversations that a user has participated in.
        /// </summary>
        /// <param name="userId">User id.</param>
        void DeleteAllUserConversations(string userId);
    }
}
