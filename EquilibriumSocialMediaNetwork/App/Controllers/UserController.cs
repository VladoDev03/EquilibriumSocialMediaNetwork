using App.Models.User;
using Data.Entities;
using Data.ViewModels;
using Data.ViewModels.Post;
using Data.ViewModels.User;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Services.Contracts;
using Services.Mappers;
using Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace App.Controllers
{
    public class UserController : Controller
    {
        private readonly UserManager<User> _userManager;
        private IPostServices postServices;
        private IUserServices userServices;
        private ICommentServices commentServices;
        private IQrCodeServices qrCodeServices;
        private IProfilePictureServices imageServices;
        private ICloudinaryServices cloudinaryServices;

        public UserController(
            IPostServices postServices,
            UserManager<User> userManager,
            IUserServices userServices,
            ICommentServices commentServices,
            IQrCodeServices qrCodeServices,
            ICloudinaryServices cloudinaryServices,
            IProfilePictureServices imageServices)
        {
            _userManager = userManager;
            this.postServices = postServices;
            this.userServices = userServices;
            this.commentServices = commentServices;
            this.qrCodeServices = qrCodeServices;
            this.cloudinaryServices = cloudinaryServices;
            this.imageServices = imageServices;
        }

        [HttpGet]
        public async Task<IActionResult> Profile()
        {
            if (!User.Identity.IsAuthenticated)
            {
                return Redirect("/Identity/Account/Login");
            }

            User user = await _userManager.GetUserAsync(User);

            List<PostViewModel> posts = postServices
                .GetUserPosts(user.Id)
                .Select(p => p.ToPostViewModel())
                .Select(p => postServices.SetReactionsCount(p))
                .ToList();

            UserViewModel result = new UserViewModel()
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                UserName = user.UserName,
                Posts = posts
            };

            ProfilePictureServiceModel image = imageServices.GetProfilePictureByUserId(user.Id);
            ProfilePictureViewModel profilePicture;

            if (image != null)
            {
                profilePicture = new ProfilePictureViewModel()
                {
                    ImageDownloadUrl = image.ImageDownloadUrl,
                    ImageUrl = image.ImageUrl,
                    IsDownloadable = image.IsDownloadable
                };

                result.ProfilePicture = profilePicture;
            }

            return View(result);
        }

        [HttpGet]
        public async Task<IActionResult> Details(string id)
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("/Identity/Account/Login");
            }

            User loggedUser = await _userManager.GetUserAsync(User);

            if (loggedUser.Id == id)
            {
                return RedirectToAction(nameof(Profile));
            }

            UserServiceModel user = userServices
                .GetUserById(id);

            UserViewModel result = user.ToUserViewModel();
            result.CanSendInvitation = userServices.IsUserFriend(loggedUser.Id, id) && userServices.IsUserInvited(loggedUser.Id, id);

            List<PostViewModel> posts = postServices
                .GetUserPosts(id)
                .Select(p => p.ToPostViewModel())
                .Select(p => postServices.SetReactionsCount(p))
                .ToList();

            ProfilePictureServiceModel image = imageServices.GetProfilePictureByUserId(id);
            ProfilePictureViewModel profilePicture;

            if (image != null)
            {
                profilePicture = new ProfilePictureViewModel()
                {
                    ImageDownloadUrl = image.ImageDownloadUrl,
                    ImageUrl = image.ImageUrl,
                    IsDownloadable = image.IsDownloadable
                };

                result.ProfilePicture = profilePicture;
            }

            result.Posts = posts;

            return View(result);
        }

        [HttpGet]
        public IActionResult CreateProfilePicture()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ProfilePictureUpload(UploadProfilePictureBindingModel input)
        {
            if (input.ProfilePicture == null)
            {
                return RedirectToAction(nameof(Profile));
            }

            byte[] data = await qrCodeServices.GetImageBytes(input.ProfilePicture);
            User user = await _userManager.GetUserAsync(User);
            string userId = user.Id;

            ProfilePictureServiceModel profilePicture = imageServices.GetProfilePictureByUserId(userId);

            if (profilePicture != null)
            {
                cloudinaryServices.DeleteImage(profilePicture.ImagePublicId);
                imageServices.DeleteProfilePicture(profilePicture.Id);
            }

            string[] imageData = cloudinaryServices.UploadImage(data, "Social media images/Profile pictures").Split("*");

            profilePicture = new ProfilePictureServiceModel();

            profilePicture.ImageUrl = imageData[0];
            profilePicture.ImagePublicId = imageData[1];
            profilePicture.IsDownloadable = input.IsDownloadable == "checked" ? true : false;
            profilePicture.ImageDownloadUrl = cloudinaryServices.GetDownloadLink(imageData[0]);
            profilePicture.UserId = userId;

            imageServices.AddProfilePicture(profilePicture, user);

            return RedirectToAction(nameof(Profile));
        }

        public async Task<IActionResult> DeleteProfilePicture()
        {
            User user = await _userManager.GetUserAsync(User);
            string userId = user.Id;

            ProfilePictureServiceModel image = imageServices.GetProfilePictureByUserId(userId);

            cloudinaryServices.DeleteImage(image.ImagePublicId);
            imageServices.DeleteProfilePicture(image.Id);

            return RedirectToAction(nameof(Profile));
        }

        public async Task<IActionResult> QrCode()
        {
            User user = await _userManager.GetUserAsync(User);
            string userId = user.Id;

            QrCodeViewModel qrCodeViewModel = null;
            QrCodeServiceModel qrCode = qrCodeServices.GetQrCodeByUserId(userId);

            if (qrCode != null)
            {
                qrCodeViewModel = new QrCodeViewModel(qrCode.ImageUrl, qrCode.ImageDownloadUrl);
                return View(qrCodeViewModel);
            }

            string dataForCode = $"https://localhost:44366/User/Details/{userId}";
            byte[] finalImage = qrCodeServices.MakeQrCode(dataForCode);
            string[] imageData = cloudinaryServices.UploadImage(finalImage, "Social media images/Qr codes").Split("*");

            qrCode = new QrCodeServiceModel();

            qrCode.ImageUrl = imageData[0];
            qrCode.PublicId = imageData[1];
            qrCode.ImageDownloadUrl = cloudinaryServices.GetDownloadLink(imageData[0]);
            qrCode.UserId = userId;

            qrCodeViewModel = new QrCodeViewModel(qrCode.ImageUrl, qrCode.ImageDownloadUrl);

            qrCodeServices.AddQrCode(qrCode, user);

            return View(qrCodeViewModel);
        }
    }
}
