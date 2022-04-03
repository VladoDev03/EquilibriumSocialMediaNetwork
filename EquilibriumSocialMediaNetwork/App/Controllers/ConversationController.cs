using Data.Entities;
using Data.ViewModels.Conversation;
using Data.ViewModels.User;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Services.Contracts;
using Services.Mappers;
using Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace App.Controllers
{
    public class ConversationController : Controller
    {
        private readonly UserManager<User> _userManager;
        private IConversationServices conversationServices;
        private IUserServices userServices;

        public ConversationController(
            UserManager<User> userManager,
            IConversationServices conversationServices,
            IUserServices userServices)
        {
            _userManager = userManager;
            this.conversationServices = conversationServices;
            this.userServices = userServices;
        }

        [HttpGet]
        public async Task<IActionResult> Chat(string id)
        {
            User user = await _userManager.GetUserAsync(User);
            User userTwo = userServices.GetUserById(id).ToUser();

            ConversationServiceModel conversation = conversationServices
                .GetConversationByTwoUserIds(userTwo.Id, user.Id);

            if (conversation == null)
            {
                conversation = new ConversationServiceModel()
                {
                    UserOneId = id,
                    UserTwoId = user.Id
                };

                conversationServices.AddConversation(conversation);
            }

            ConversationViewModel twoUsersWithConversation =
                new ConversationViewModel(
                    user.Id,
                    userTwo.Id,
                    userTwo.UserName,
                    userTwo.FirstName,
                    userTwo.LastName,
                    conversation.Id);

            return View(twoUsersWithConversation);
        }

        [HttpGet("/Conversation/{id}")]
        public IActionResult Index(string id)
        {
            ConversationServiceModel conversation =
                conversationServices.GetConversationById(id);

            string usernameOne = userServices.GetUserById(conversation.UserOneId).UserName;
            string usernameTwo = userServices.GetUserById(conversation.UserTwoId).UserName;

            return Ok(new
            {
                UsernameOne = usernameOne,
                UsernameTwo = usernameTwo,
                Messages = conversation.Messages.Select(message => new
                {
                    Content = message.Content,
                    UsernameOne = message.UserOne.UserName,
                    UsernameTwo = message.UserTwo.UserName,
                })
                .ToList()
            });
        }
    }
}
