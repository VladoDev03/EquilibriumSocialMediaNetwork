﻿using Data.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Services.Contracts;
using Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace App.Controllers
{
    public class PostController : Controller
    {
        private readonly UserManager<User> _userManager;
        private IPostServices postServices;

        public PostController(
            IPostServices postServices,
            UserManager<User> userManager)
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
        public async Task<IActionResult> Create(PostServiceModel post)
        {
            User user = await _userManager.GetUserAsync(User);
            post.User = user;
            postServices.AddPost(post);

            return RedirectToAction("Index", "Home");
        }
    }
}
