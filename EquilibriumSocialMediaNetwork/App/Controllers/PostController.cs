using App.Models.Comments;
using App.Models.Posts;
using Data.Entities;
using Data.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Services.Contracts;
using Services.Mappers;
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

        public PostController(
            UserManager<User> userManager,
            IPostServices postServices)
        {
            _userManager = userManager;
            this.postServices = postServices;
        }

        [Authorize(Roles = "User, Admin")]
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [Authorize(Roles = "User, Admin")]
        [HttpPost]
        public async Task<IActionResult> Create(CreatePostBindingModel post)
        {
            PostServiceModel postToAdd = new PostServiceModel();

            postToAdd.Content = post.Content;

            User user = await _userManager.GetUserAsync(User);
            postToAdd.User = user;

            if (post.Image != null)
            {
                postToAdd.Image = post.Image.Name;
            }

            postServices.AddPost(postToAdd);

            return RedirectToAction("Index", "Home");
        }

        public IActionResult DeletePost(string id)
        {
            postServices.DeletePost(id);

            return RedirectToAction("Profile", "User");
        }

        [HttpGet]
        public IActionResult Update(EditPostBindingModel newData)
        {
            PostViewModel post = postServices
                .GetPostById(newData.Id)
                .ToPostViewModel();

            return View(post);
        }

        [HttpPost]
        public IActionResult UpdatePost(EditPostBindingModel newData)
        {
            PostServiceModel post = new PostServiceModel()
            {
                Id = newData.Id,
                Content = newData.Content
            };

            postServices.UpdatePost(post);

            return RedirectToAction("Profile", "User");
        }
    }
}
