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
        private IPostServices postServices;
        private ICloudinaryServices cloudinaryServices;

        public PostController(
            UserManager<User> userManager,
            IPostServices postServices,
            ICloudinaryServices cloudinaryServices)
        {
            _userManager = userManager;
            this.postServices = postServices;
            this.cloudinaryServices = cloudinaryServices;
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
            if (post.Content == null && post.Image == null)
            {
                ViewData.Add("NotEmptyContent", "You can't create empty posts.");
                return View();
            }

            PostServiceModel postToAdd = new PostServiceModel();

            postToAdd.Content = post.Content;
            postToAdd.IsDownloadable = post.IsDownloadable == "checked" ? true : false;

            User user = await _userManager.GetUserAsync(User);
            postToAdd.User = user;

            if (post.Image != null)
            {
                byte[] data = await GetImageBytes(post.Image);
                string[] imageData = cloudinaryServices.UploadImage(data).Split("*");

                postToAdd.ImageUrl = imageData[0];
                postToAdd.ImagePublicId = imageData[1];
                postToAdd.ImageDownloadUrl = cloudinaryServices.GetDownloadLink(imageData[0]);
            }

            postServices.AddPost(postToAdd);

            return RedirectToAction("Index", "Home");
        }

        public IActionResult DeletePost(string id)
        {
            PostServiceModel post = postServices.GetPostById(id);

            postServices.DeletePost(id);

            if (post.ImagePublicId != null)
            {
                cloudinaryServices.DeleteImage(post.ImagePublicId);
            }

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

        private async Task<byte[]> GetImageBytes(IFormFile file)
        {
            using (MemoryStream memoryStream = new MemoryStream())
            {
                await file.CopyToAsync(memoryStream);
                byte[] img = memoryStream.ToArray();

                return img;
            }
        }
    }
}
