using App.Models.Comments;
using Data.Entities;
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
    public class CommentController : Controller
    {
        private readonly UserManager<User> _userManager;
        private IPostServices postServices;
        private ICommentServices commentServices;

        public CommentController(
            UserManager<User> userManager,
            IPostServices postServices,
            ICommentServices commentServices)
        {
            _userManager = userManager;
            this.postServices = postServices;
            this.commentServices = commentServices;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromForm]CreateCommentBindingModel comment, string id)
        {
            if (comment.Content == null)
            {
                TempData.Add("NotEmptyComment", "You can't create empty comments.");
                return RedirectToAction("Index", "Home");
            }

            User user = await _userManager.GetUserAsync(User);
            PostServiceModel post = postServices.GetPostById(id);

            CommentServiceModel commentToAdd = new CommentServiceModel()
            {
                Content = comment.Content,
                PostId = id,
                UserId = user.Id,
                User = user
            };

            commentServices.AddComment(post, commentToAdd);

            return RedirectToAction("Index", "Home");
        }

        public IActionResult DeleteComment(string id)
        {
            commentServices.DeleteComment(id);

            return Redirect(Request.Headers["Referer"].ToString());
        }
    }
}
