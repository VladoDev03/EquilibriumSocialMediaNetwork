using Data.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Services.Contracts;
using Services.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace App.Controllers
{
    public class PostController : Controller
    {
        private readonly UserManager<User> _userManager;
        private IPostServices postServices;
        private ICommentServices commentServices;

        public PostController(
            IPostServices postServices,
            UserManager<User> userManager,
            ICommentServices commentServices)
        {
            _userManager = userManager;
            this.postServices = postServices;
            this.commentServices = commentServices;
        }

        [Authorize(Roles = "User, Admin")]
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [Authorize(Roles = "User, Admin")]
        [HttpPost]
        public async Task<IActionResult> Create(PostServiceModel post, IFormFile pic)
        {
            User user = await _userManager.GetUserAsync(User);
            post.User = user;

            if (pic != null)
            {
                post.Image = pic.Name;
            }

            postServices.AddPost(post);

            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public async Task<IActionResult> CommentOnPost(string id, string content)
        {
            User user = await _userManager.GetUserAsync(User);
            PostServiceModel post = postServices.GetPostById(id);

            CommentServiceModel commentToAdd = new CommentServiceModel()
            {
                Content = content,
                PostId = id,
                UserId = user.Id,
                User = user
            };

            CommentServiceModel c = commentServices.AddComment(post, commentToAdd);

            return RedirectToAction("Index", "Home");
        }
    }
}
