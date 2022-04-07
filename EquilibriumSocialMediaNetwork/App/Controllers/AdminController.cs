using Data.Entities;
using Data.ViewModels.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Services.Contracts;
using Services.Mappers;
using Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace App.Controllers
{
    public class AdminController : Controller
    {
        private readonly UserManager<User> _userManager;
        private IUserServices userServices;
        private IProfilePictureServices imageServices;
        private ICloudinaryServices cloudinaryServices;
        private IAdminServices adminServices;

        public AdminController(
            UserManager<User> userManager,
            IUserServices userServices,
            IProfilePictureServices imageServices,
            ICloudinaryServices cloudinaryServices,
            IAdminServices adminServices)
        {
            _userManager = userManager;
            this.userServices = userServices;
            this.imageServices = imageServices;
            this.cloudinaryServices = cloudinaryServices;
            this.adminServices = adminServices;
        }

        [Authorize(Roles = "Admin")]
        public IActionResult BanUser(string userId)
        {
            adminServices.DeleteUserProfile(userId);
            userServices.DeleteUser(userId);

            return RedirectToAction(nameof(AllUsers));
        }

        [Authorize(Roles = "Admin")]
        public IActionResult AllUsers()
        {
            List<UserViewModel> allUsers = userServices
                .GetUsers()
                .Select(u => u.ToUserViewModel())
                .ToList();

            foreach (UserViewModel user in allUsers)
            {
                user.IsAdmin = userServices.IsUserAdmin(user.Id);
            }

            return View(allUsers);
        }

        [Authorize(Roles = "Admin")]
        public IActionResult DeleteProfilePictureAdmin(string id)
        {
            ProfilePictureServiceModel image = imageServices.GetProfilePictureByUserId(id);

            cloudinaryServices.DeleteImage(image.ImagePublicId);
            imageServices.DeleteProfilePicture(image.Id);

            return Redirect(Request.Headers["Referer"].ToString());
        }

        [Authorize(Roles = "Admin")]
        public IActionResult MakeAdmin(string userId)
        {
            if (userId != null)
            {
                userServices.MakeUserAdmin(userId);
            }

            return RedirectToAction(nameof(AllUsers));
        }
    }
}
