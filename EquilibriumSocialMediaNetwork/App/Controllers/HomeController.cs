using App.Models;
using Data.Entities;
using Data.ViewModels;
using Data.ViewModels.Post;
using Data.ViewModels.User;
using JsonManager.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Services;
using Services.Contracts;
using Services.Mappers;
using Services.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace App.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly UserManager<User> _userManager;
        private IUserServices userServices;
        private IUserFriendServices userFriendServices;
        private IJsonUserManager userJsonServices;
        private IPostServices postServices;

        public HomeController(
            ILogger<HomeController> logger,
            UserManager<User> userManager,
            IUserServices userServices,
            IUserFriendServices userFriendServices,
            IJsonUserManager userJsonServices,
            IPostServices postServices)
        {
            _logger = logger;
            _userManager = userManager;
            this.userServices = userServices;
            this.userJsonServices = userJsonServices;
            this.postServices = postServices;
            this.userFriendServices = userFriendServices;
        }

        public async Task<IActionResult> Index()
        {
            if (!User.Identity.IsAuthenticated)
            {
                return Redirect("/Identity/Account/Login");
            }

            User user = await _userManager.GetUserAsync(User);

            string userId = user.Id;

            List<PostViewModel> posts = postServices
                .GetPostsForUser(userId)
                .Select(p => p.ToPostViewModel())
                .Select(p => postServices.SetReactionsCount(p))
                .ToList();

            posts.ForEach(p => p.IsLikedByUser = postServices.IsReactedByUser(p.Id, user.Id, "like"));
            posts.ForEach(p => p.IsDislikedByUser = postServices.IsReactedByUser(p.Id, user.Id, "dislike"));

            return View(posts);
        }

        [Authorize(Roles = "User, Admin")]
        [HttpGet("users")]
        public async Task<string> Search()
        {
            User user = await _userManager.GetUserAsync(User);

            List<UserSearchView> users = userServices
                .GetUsers()
                .Where(u => u.Id != user.Id)
                .Select(u => new UserSearchView()
                {
                    UserName = u.UserName,
                    FirstName = u.FirstName,
                    LastName = u.LastName,
                    Email = u.Email,
                    Url = $"https://localhost:44366/User/Details/{u.Id}"
                }).ToList();

            string result = userJsonServices.AllUsersToJson(users);

            return result;
        }

        [HttpGet]
        public async Task<IActionResult> UsersToChatWith()
        {
            User user = await _userManager.GetUserAsync(User);

            List<UserViewModel> chats = userFriendServices
                .GetUserFriends(user.Id)
                .Select(uf => uf.FriendId)
                .Select(id => userServices.GetUserById(id))
                .Select(u => u.ToUserViewModel())
                .ToList();

            return View(chats);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
