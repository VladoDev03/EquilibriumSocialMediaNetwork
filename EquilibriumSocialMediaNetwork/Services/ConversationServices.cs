﻿using Data;
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
            throw new NotImplementedException();
        }
    }
}
