using App.Models;
using Data.Entities;
using Data.Models;
using JsonManager.Contracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Services;
using Services.Contracts;
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

        public HomeController(
            ILogger<HomeController> logger,
            IUserServices userServices,
            IJsonUserManager userJsonServices)
        {
            _logger = logger;
            this.userServices = userServices;
            this.userJsonServices = userJsonServices;
        }

        public IActionResult Index()
        {
            if (!User.Identity.IsAuthenticated)
            {
                return Redirect("/Identity/Account/Login");
            }

            return View();
        }

        [HttpGet("users")]
        public string Search()
        {
            List<UserSearchView> users = userServices.GetUsers().Select(u => new UserSearchView()
            {
                UserName = u.UserName,
                FirstName = u.FirstName,
                LastName = u.LastName
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
