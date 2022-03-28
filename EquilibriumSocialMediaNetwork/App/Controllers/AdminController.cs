using Data.ViewModels.User;
using Microsoft.AspNetCore.Authorization;
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
        private IUserServices userServices;
        private IProfilePictureServices imageServices;
        private ICloudinaryServices cloudinaryServices;

        public AdminController(IUserServices userServices)
        {
            this.userServices = userServices;
        }

        [Authorize(Roles = "Admin")]
        public IActionResult AllUsersAdmin()
        {
            List<UserViewModel> allUsers = userServices
                .GetUsers()
                .Select(u => u.ToUserViewModel())
                .ToList();

            return View(allUsers);
        }

        [Authorize(Roles = "Admin")]
        public IActionResult DeleteProfilePictureAdmin(string id)
        {
            ProfilePictureServiceModel image = imageServices.GetProfilePictureByUserId(id);

            cloudinaryServices.DeleteImage(image.ImagePublicId);
            imageServices.DeleteProfilePicture(image.Id);

            return RedirectToAction(nameof(AllUsersAdmin));
        }
    }
}
