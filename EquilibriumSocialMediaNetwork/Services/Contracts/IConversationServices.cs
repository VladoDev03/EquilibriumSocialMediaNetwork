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
        List<ConversationServiceModel> GetAllConversations();

        List<ConversationServiceModel> GetUserConversations(string userId);

        ConversationServiceModel GetConversationByTwoUserIds(string userIdOne, string userIdTwo);

        ConversationServiceModel GetConversationById(string id);

        ConversationServiceModel AddConversation(ConversationServiceModel conversation);

        void RemoveConversation(string conversationId);

        void DeleteConversationByUserIds(string userIdOne, string userIdTwo);

        void DeleteAllUserConversations(string userId);
    }
}
