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
        private IJsonUserManager userJsonServices;
        private IPostServices postServices;

        public HomeController(
            ILogger<HomeController> logger,
            UserManager<User> userManager,
            IUserServices userServices,
            IJsonUserManager userJsonServices,
            IPostServices postServices)
        {
            _logger = logger;
            _userManager = userManager;
            this.userServices = userServices;
            this.userJsonServices = userJsonServices;
            this.postServices = postServices;
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
                .ToList();

            return View(posts);
        }

        [Authorize(Roles = "User, Admin")]
        [HttpGet("users")]
        public string Search()
        {
            List<UserSearchView> users = userServices.GetUsers().Select(u => new UserSearchView()
            {
                UserName = u.UserName,
                FirstName = u.FirstName,
                LastName = u.LastName,
                Email = u.Email
            }).ToList();

            string result = userJsonServices.AllUsersToJson(users);

            return result;
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
