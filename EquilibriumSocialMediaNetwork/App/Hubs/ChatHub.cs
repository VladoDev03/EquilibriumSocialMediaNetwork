﻿using Data.Entities;
using Microsoft.AspNetCore.SignalR;
using Services.Contracts;
using Services.Mappers;
using Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace App.Hubs
{
    public class ChatHub : Hub
    {
        private readonly ISessionServices sessionService;
        private IMessageServices messageServices;
        private IConversationServices conversationServices;
        private IUserServices userServices;

        public ChatHub(
            ISessionServices service,
            IMessageServices messageServices,
            IConversationServices conversationServices,
            IUserServices userServices)
        {
            sessionService = service;
            this.messageServices = messageServices;
            this.conversationServices = conversationServices;
            this.userServices = userServices;
        }

        public override Task OnConnectedAsync()
        {
            string connectionId = Context.ConnectionId;
            var user = Context.User;
            string userId = user.FindFirst(ClaimTypes.NameIdentifier).Value;

            sessionService.AddSession(connectionId, userId);

            return Task.CompletedTask;
        }

        public override Task OnDisconnectedAsync(Exception exception)
        {
            return base.OnDisconnectedAsync(exception);
        }

        public async Task SendMessage(string idOne, string idTwo, string message)
        {
            User userOne = userServices.GetUserById(idOne).ToUser();
            User userTwo = userServices.GetUserById(idTwo).ToUser();

            ConversationServiceModel conversation =
                conversationServices.GetConversationByTwoUserIds(idOne, idTwo);

            if (conversation == null)
            {
                conversation = new ConversationServiceModel()
                {
                    UserOneId = idOne,
                    UserTwoId = idTwo,
                };

                conversationServices.AddConversation(conversation);
            }

            MessageServiceModel messageEntity = new MessageServiceModel()
            {
                Content = message,
                ConversationId = conversation.Id,
                UserOneId = userOne.Id,
                UserTwoId = userTwo.Id
            };

            messageServices.AddMessage(messageEntity);

            string userOneConnectionId = sessionService.GetSession(userOne.Id);
            string userTwoConnectionId = sessionService.GetSession(userTwo.Id);

            if (userOneConnectionId != null)
            {
                await Clients.Client(userOneConnectionId).SendAsync("ReceiveMessage", $"[{userOne.UserName}] sends {messageEntity.Content} to [{userTwo.UserName}]");
            }

            if (userTwoConnectionId != null)
            {
                await Clients.Client(userTwoConnectionId).SendAsync("ReceiveMessage", $"[{userOne.UserName}] sends {messageEntity.Content} to [{userTwo.UserName}]");
            }
        }
    }
}
