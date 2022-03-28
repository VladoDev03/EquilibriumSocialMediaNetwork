using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Data.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using Services.Contracts;

namespace App.Areas.Identity.Pages.Account.Manage
{
    public class DeletePersonalDataModel : PageModel
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly ILogger<DeletePersonalDataModel> _logger;
        private IPostServices postServices;
        private ICommentServices commentServices;
        private IQrCodeServices qrCodeServices;
        private IProfilePictureServices profilePictureServices;
        private IReactionServices reactionServices;
        private ICloudinaryServices cloudinaryServices;
        private IFriendRequestServices friendRequestServices;
        private IUserFriendServices userFriendServices;

        public DeletePersonalDataModel(
            UserManager<User> userManager,
            SignInManager<User> signInManager,
            ILogger<DeletePersonalDataModel> logger,
            IPostServices postServices,
            ICommentServices commentServices,
            IQrCodeServices qrCodeServices,
            IProfilePictureServices profilePictureServices,
            IReactionServices reactionServices,
            ICloudinaryServices cloudinaryServices,
            IFriendRequestServices friendRequestServices,
            IUserFriendServices userFriendServices)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = logger;
            this.postServices = postServices;
            this.commentServices = commentServices;
            this.qrCodeServices = qrCodeServices;
            this.profilePictureServices = profilePictureServices;
            this.reactionServices = reactionServices;
            this.cloudinaryServices = cloudinaryServices;
            this.friendRequestServices = friendRequestServices;
            this.userFriendServices = userFriendServices;
        }

        [BindProperty]
        public InputModel Input { get; set; }

        public class InputModel
        {
            [Required]
            [DataType(DataType.Password)]
            public string Password { get; set; }
        }

        public bool RequirePassword { get; set; }

        public async Task<IActionResult> OnGet()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            RequirePassword = await _userManager.HasPasswordAsync(user);
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            RequirePassword = await _userManager.HasPasswordAsync(user);
            if (RequirePassword)
            {
                if (!await _userManager.CheckPasswordAsync(user, Input.Password))
                {
                    ModelState.AddModelError(string.Empty, "Incorrect password.");
                    return Page();
                }
            }

            await DeleteUserData();

            var result = await _userManager.DeleteAsync(user);
            var userId = await _userManager.GetUserIdAsync(user);

            if (!result.Succeeded)
            {
                throw new InvalidOperationException($"Unexpected error occurred deleting user with ID '{userId}'.");
            }

            await _signInManager.SignOutAsync();

            _logger.LogInformation("User with ID '{UserId}' deleted themselves.", userId);

            return Redirect("~/");
        }

        private async Task DeleteUserData()
        {
            User userToRemove = await _userManager.GetUserAsync(User);

            postServices.GetAllPosts().ForEach(p => postServices.DeletePostComments(p.Id));
            postServices.GetAllPosts().ForEach(p => reactionServices.DeletePostReactions(p.Id));
            postServices.GetAllPosts().ForEach(p => cloudinaryServices.DeleteImage(p.ImagePublicId));

            postServices.DeleteUserPosts(userToRemove.Id);
            commentServices.DeleteUserComments(userToRemove.Id);
            reactionServices.DeleteUserReactions(userToRemove.Id);

            cloudinaryServices.DeleteImage(cloudinaryServices.FindQrCodePublicIdById(userToRemove.QrCodeId));
            qrCodeServices.DeleteQrCode(userToRemove.QrCodeId);

            cloudinaryServices.DeleteImage(cloudinaryServices.FindProfilePicturePublicIdById(userToRemove.ProfilePictureId));
            profilePictureServices.DeleteProfilePicture(userToRemove.ProfilePictureId);

            friendRequestServices.DeleteAllFriendRequestByReveiverId(userToRemove.Id);
            friendRequestServices.DeleteAllFriendRequestBySenderId(userToRemove.Id);

            userFriendServices.RemoveAllFriends(userToRemove.Id);
        }
    }
}
