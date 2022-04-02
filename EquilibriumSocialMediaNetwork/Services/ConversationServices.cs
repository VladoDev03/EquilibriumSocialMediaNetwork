using Data;
using Services.Contracts;
using Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class ConversationServices : IConversationServices
    {
        private EquilibriumDbContext db;

        public ConversationServices(EquilibriumDbContext db)
        {
            this.db = db;
        }

        public ConversationServiceModel AddConversation(ConversationServiceModel conversation)
        {
            throw new NotImplementedException();
        }

        public List<ConversationServiceModel> GetAllConversation()
        {
            throw new NotImplementedException();
        }

        public ConversationServiceModel GetConversationById(string id)
        {
            throw new NotImplementedException();
        }

        public ConversationServiceModel GetConversationByTwoUserIds(string userIdOne, string userIdTwo)
        {
            throw new NotImplementedException();
        }

        public List<ConversationServiceModel> GetUserConversations(string userId)
        {
            throw new NotImplementedException();
        }
    }
}
