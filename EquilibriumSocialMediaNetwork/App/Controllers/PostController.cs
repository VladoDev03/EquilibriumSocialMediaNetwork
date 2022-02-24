using System;
using System.Threading.Tasks;
using Data.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Services
{
    public class UserController:Controller 
    {
        private IUserServices userServices;
        private UserManager<User> userManager;

        public UserController(IUserServices userServices, UserManager<User> userManager)
        {
            this.userServices = userServices;
            this.userManager = userManager;
        }

        [HttpGet]
        private IActionResult CreatePost()
        {
            if (!this.User.Identity.IsAuthenticated)
            {
                return Redirect("Index");
            }

            return View();
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> CreatePost (Post post)
        {
            User user = await this.userManager.GetUserAsync(this.User);
            this.userServices.CreatePost(post);
            return RedirectToAction("Create");
        }


        [HttpPost]
        public IActionResult EditPost(Post updatePost)
        {
            this.userServices.UpdatePost(updatePost);
            return RedirectToAction("Index");
        }

        [HttpPost]
        [ActionName ("Delete")]
        public IActionResult DeletePost(string id)
        {
            if (id == null)
            {
                return RedirectToAction("Index");
            }

            this.userServices.DeletePost(id);

            return RedirectToAction("Index");

        }

       
    }
}
