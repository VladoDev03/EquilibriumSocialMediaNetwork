using Data.Entities;
using Data.ViewModels;
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
    public class UserController : Controller
    {

        private readonly UserManager<User> _userManager;
        private IPostServices postServices;
        private ICommentServices commentServices;

        public UserController(
            IPostServices postServices,
            UserManager<User> userManager,
            ICommentServices commentServices)
        {
            _userManager = userManager;
            this.postServices = postServices;
            this.commentServices = commentServices;
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
    }
}
