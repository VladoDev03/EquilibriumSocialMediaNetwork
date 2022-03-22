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
    public class ReactionController : Controller
    {
        private readonly UserManager<User> _userManager;
        private IReactionServices reactionServices;
        private IPostServices postServices;

        public ReactionController(
            IReactionServices reactionServices,
            UserManager<User> userManager,
            IPostServices postServices)
        {
            this.reactionServices = reactionServices;
            _userManager = userManager;
            this.postServices = postServices;
        }

        [Route("/Reaction/AddReaction/{name}/{postId}")]
        public async Task<IActionResult> AddReaction(string name, string postId)
        {
            User currentUser = await _userManager.GetUserAsync(User);

            ReactionServiceModel reaction = new ReactionServiceModel()
            {
                Name = name,
                PostId = postId,
                User = currentUser,
                UserId = currentUser.Id
            };

            reactionServices.AddReaction(reaction);

            return RedirectToAction("Index", "Home");
        }
    }
}
