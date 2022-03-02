using App.Models.Comments;
using App.Models.Posts;
using Data.Entities;
using Data.ViewModels;
using Data.ViewModels.Post;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
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
        private IWebHostEnvironment environment;
        private IPostServices postServices;

        public PostController(
            UserManager<User> userManager,
            IPostServices postServices,
            IWebHostEnvironment environment)
        {
            _userManager = userManager;
            this.postServices = postServices;
            this.environment = environment;
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
                string path = await SaveImageAsync(post.Image);
                postToAdd.Image = path;
            }

            postServices.AddPost(postToAdd);

            return RedirectToAction("Index", "Home");
        }

        public IActionResult DeletePost(string id)
        {
            PostServiceModel post = postServices.GetPostById(id);
            string path = Path.Combine(environment.WebRootPath, "Images", "Posts", post.Image);

            postServices.DeletePost(id);
            System.IO.File.Delete(path);

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

        private async Task<string> SaveImageAsync(IFormFile file)
        {
            if (file == null || file.Length == 0)
            {
                return "";
            }

            using (MemoryStream memoryStream = new MemoryStream())
            {
                await file.CopyToAsync(memoryStream);

                byte[] img = memoryStream.ToArray();
                string fileName = $"{Guid.NewGuid()}{file.FileName}";
                string path = Path.Combine(environment.WebRootPath, "Images", "Posts", fileName);

                await System.IO.File.WriteAllBytesAsync(path, img);
                return fileName;
            }
        }
    }
}
