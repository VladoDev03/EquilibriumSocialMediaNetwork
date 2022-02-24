using Data.Entities;
using Data.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Services.Contracts;
using Services.Mappers;
using Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace App.Controllers
{
    public class UserController : Controller
    {

        private readonly UserManager<User> _userManager;
        private IPostServices postServices;
        private IUserServices userServices;

        public UserController(
            IPostServices postServices,
            UserManager<User> userManager,
            IUserServices userServices)
        {
            _userManager = userManager;
            this.postServices = postServices;
            this.userServices = userServices;
        }

        [HttpGet]
        public async Task<IActionResult> Profile()
        {
            User user = await _userManager.GetUserAsync(User);

            List<PostViewModel> posts = postServices
                .GetUserPosts(user.Id)
                .Select(p => p.ToPostViewModel())
                .ToList();

            UserViewModel result = new UserViewModel()
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                UserName = user.UserName,
                Posts = posts
            };

            return View(result);
        }

        [HttpGet]
        public async Task<IActionResult> Details(string id)
        {
            User loggedUser = await _userManager.GetUserAsync(User);

            if (loggedUser.Id == id)
            {
                return RedirectToAction(nameof(Profile));
            }

            UserServiceModel user = userServices
                .GetUserById(id);

            UserViewModel u = user.ToUserViewModel();

            List<PostViewModel> posts = postServices
                .GetUserPosts(id)
                .Select(p => p.ToPostViewModel())
                .ToList();

            UserViewModel result = new UserViewModel()
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                UserName = user.UserName,
                Posts = posts
            };

            return View(result);
        }
    }
}
