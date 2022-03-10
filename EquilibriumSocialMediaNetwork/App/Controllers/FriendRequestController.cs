using Data.Entities;
using Data.ViewModels.FriendRequest;
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
        public async Task<IActionResult> Invites()
        {
            User currentUser = await _userManager.GetUserAsync(User);

            List<FriendRequestViewModel> invites = friendRequestServices
                .GetUserInvitations(currentUser.Id)
                .Select(fr => fr.ToFriendRequestViewModel())
                .ToList();

            return View(invites);
        }

        [HttpGet]
        public async Task<IActionResult> PendingRequests()
        {
            User currentUser = await _userManager.GetUserAsync(User);

            List<FriendRequestViewModel> invites = friendRequestServices
                .GetPendingRequests(currentUser.Id)
                .Select(fr => fr.ToFriendRequestViewModel())
                .ToList();

            return View(invites);
        }
    }
}
