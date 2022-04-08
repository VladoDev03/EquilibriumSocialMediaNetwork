using Data.Entities;
using Data.ViewModels.UserFriend;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Services.Contracts;
using Services.Mappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace App.Controllers
{
    public class FriendController : Controller
    {
        private readonly UserManager<User> _userManager;
        private IUserFriendServices userFriendServices;

        public FriendController(
            UserManager<User> userManager,
            IUserFriendServices userFriendServices)
        {
            _userManager = userManager;
            this.userFriendServices = userFriendServices;
        }

        public async Task<IActionResult> FriendsList()
        {
            User user = await _userManager.GetUserAsync(User);
            string id = user.Id;

            List<UserFriendViewModel> friends = userFriendServices
                .GetUserFriends(id)
                .Select(f => f.ToUserFriendViewModel())
                .ToList();

            return View(friends);
        }

        public async Task<IActionResult> RemoveFriend(string id)
        {
            User user = await _userManager.GetUserAsync(User);

            userFriendServices.RemoveUserFriend(user.Id, id);

            return Redirect(Request.Headers["Referer"].ToString());
        }
    }
}
