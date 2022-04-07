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
        public async Task<IActionResult> InvitesAndRequests()
        {
            User currentUser = await _userManager.GetUserAsync(User);

            List<FriendRequestViewModel> invites = friendRequestServices
                .GetUserInvitations(currentUser.Id)
                .Select(fr => fr.ToFriendRequestViewModel())
                .ToList();

            List<FriendRequestViewModel> pending = friendRequestServices
                .GetPendingRequests(currentUser.Id)
                .Select(fr => fr.ToFriendRequestViewModel())
                .ToList();

            InvitesViewModel invitesViewModel = new InvitesViewModel()
            {
                Invites = invites,
                Pending = pending
            };

            return View(invitesViewModel);
        }

        [HttpGet]
        public async Task<IActionResult> Accept(string id)
        {
            User user = await _userManager.GetUserAsync(User);

            friendRequestServices.ApproveFriendRequest(user.Id, id);

            return Redirect(Request.Headers["Referer"].ToString());
        }

        [HttpGet]
        public async Task<IActionResult> Reject(string id)
        {
            User user = await _userManager.GetUserAsync(User);

            friendRequestServices.RejectFriendRequest(user.Id, id);

            return Redirect(Request.Headers["Referer"].ToString());
        }

        public async Task<IActionResult> Delete(string id)
        {
            User user = await _userManager.GetUserAsync(User);

            friendRequestServices.DeleteFriendRequest(user.Id, id);

            return Redirect(Request.Headers["Referer"].ToString());
        }
    }
}
