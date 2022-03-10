using Data.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Services;
using Services.Contracts;
using Services.Mappers;
using Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace App.Controllers
{
    public class FriendRequestController : Controller
    {
        private readonly UserManager<User> _userManager;
        private IFriendRequestServices friendRequestServices;
        private IUserServices userServices;

        public FriendRequestController(
            IFriendRequestServices friendRequestServices,
            IUserServices userServices,
            UserManager<User> userManager)
        {
            this.friendRequestServices = friendRequestServices;
            this.userServices = userServices;
            _userManager = userManager;
        }

        [HttpGet]
        public async Task<IActionResult> SendRequest(string id)
        {
            UserServiceModel receiver = userServices.GetUserById(id);
            User currentUser = await _userManager.GetUserAsync(User);
            UserServiceModel sender = currentUser.ToUserServiceModel();

            friendRequestServices.SentFriendRequestToUser(sender, receiver);

            return RedirectToAction("Details", "User", new { Id = id });
        }

        [HttpGet]
        public async Task<IActionResult> AllRequests()
        {
            User currentUser = await _userManager.GetUserAsync(User);

            List<FriendRequestServiceModel> invites = friendRequestServices
                .GetUserInvitations(currentUser.Id);

            return View(invites);
        }
    }
}
