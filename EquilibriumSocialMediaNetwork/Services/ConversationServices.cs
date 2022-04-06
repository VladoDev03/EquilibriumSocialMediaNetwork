using Data;
using Data.Entities;
using Microsoft.EntityFrameworkCore;
using Services.Contracts;
using Services.Mappers;
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
            db.Conversations.Add(conversation.ToConversation());

            db.SaveChanges();

            return conversation;
        }

        public List<ConversationServiceModel> GetAllConversations()
        {
            List<ConversationServiceModel> conversations = db.Conversations
                .Include(c => c.Messages)
                .Select(c => c.ToConversationServiceModel())
                .ToList();

            return conversations;
        }

        public ConversationServiceModel GetConversationById(string id)
        {
            ConversationServiceModel conversation = db.Conversations
                .Include(c => c.Messages)
                .SingleOrDefault(c => c.Id == id)
                .ToConversationServiceModel();

            return conversation;
        }

        public ConversationServiceModel GetConversationByTwoUserIds(string userIdOne, string userIdTwo)
        {
            Conversation result = db.Conversations
                .Include(c => c.Messages)
                .FirstOrDefault(c => (c.UserOneId == userIdOne && c.UserTwoId == userIdTwo)
                            || (c.UserOneId == userIdTwo && c.UserTwoId == userIdOne));

            if (result == null)
            {
                return null;
            }

            return result.ToConversationServiceModel();
        }

        public List<ConversationServiceModel> GetUserConversations(string userId)
        {
            List<ConversationServiceModel> conversations = db.Conversations
                .Where(c => c.UserOneId == userId || c.UserTwoId == userId)
                .Select(c => c.ToConversationServiceModel())
                .ToList();

            return conversations;
        }

        public void DeleteAllUserConversations(string userId)
        {
            List<Conversation> conversations = db.Conversations
                   .Where(c => c.UserOneId == userId || c.UserTwoId == userId)
                   .ToList();

            db.Conversations.RemoveRange(conversations);
            db.SaveChanges();
        }

        public void RemoveConversation(string conversationId)
        {
            Conversation conversation = db.Conversations.FirstOrDefault(c => c.Id == conversationId);

            db.Conversations.Remove(conversation);

            db.SaveChanges();
        }

        public void DeleteConversationByUserIds(string userIdOne, string userIdTwo)
        {
            Conversation conversation = db.Conversations
                   .FirstOrDefault(c => (c.UserOneId == userIdOne && c.UserTwoId == userIdTwo)
                        || (c.UserOneId == userIdTwo && c.UserTwoId == userIdOne));

            db.Conversations.Remove(conversation);

            db.SaveChanges();
        }
    }
}
