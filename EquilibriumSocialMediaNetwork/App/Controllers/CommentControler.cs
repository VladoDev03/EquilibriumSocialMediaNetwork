using System;
using System.Threading.Tasks;
using Data.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Services;

namespace App.Controllers
{
    public class CommentControler : Controller
    {
        private IUserServices userServices;
        private UserManager<User> userManager;

        public CommentControler(IUserServices userServices, UserManager<User> userManager)
        {
            this.userServices = userServices;
            this.userManager = userManager;
        }

        [HttpGet]
        private IActionResult AddComment()
        {
            if (!this.User.Identity.IsAuthenticated)
            {
                return Redirect("Index");
            }

            return View();
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> AddComment(Comment comment)
        {
            User user = await this.userManager.GetUserAsync(this.User);
            this.userServices.AddComment(comment);
            return RedirectToAction("Add Comment");
        }


        [HttpPost]
        public IActionResult UpdateComment(Comment updateComment)
        {
            this.userServices.UpdateComment(updateComment);
            return RedirectToAction("Index");
        }

        [HttpPost]
        [ActionName("Delete comment")]
        public IActionResult DeleteComment(string id)
        {
            if (id == null)
            {
                return RedirectToAction("Index");
            }

            this.userServices.DeleteComment(id);

            return RedirectToAction("Index");



        }
    }
}
