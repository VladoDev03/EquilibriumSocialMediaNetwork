using App.Models;
using Data.Entities;
using Data.Models;
using JsonManager.Contracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Services;
using Services.Contracts;
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

        private IUserServices userServices;
        private IJsonUserManager userJsonServices;
        private IPostServices postServices;

        public HomeController(
            ILogger<HomeController> logger,
            IUserServices userServices,
            IJsonUserManager userJsonServices,
            IPostServices postServices)
        {
            _logger = logger;
            this.userServices = userServices;
            this.userJsonServices = userJsonServices;
            this.postServices = postServices;
        }

        public IActionResult Index()
        {
            if (!User.Identity.IsAuthenticated)
            {
                return Redirect("/Identity/Account/Login");
            }

            List<PostServiceModel> posts = postServices.GetAllPosts();

            return View(posts);
        }

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
