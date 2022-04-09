using App.BindingModels.Reactions;
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

        public ReactionController(
            IReactionServices reactionServices,
            UserManager<User> userManager)
        {
            this.reactionServices = reactionServices;
            _userManager = userManager;
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

            return Redirect(Request.Headers["Referer"].ToString());
        }

        [HttpPost("/addReaction")]
        public async Task<IActionResult> JsonAddReaction([FromBody] CreateReactionBindingModel newReaction)
        {
            User currentUser = await _userManager.GetUserAsync(User);

            ReactionServiceModel reaction = new ReactionServiceModel()
            {
                Name = newReaction.Name,
                PostId = newReaction.PostId,
                User = currentUser,
                UserId = currentUser.Id
            };

            reactionServices.AddReaction(reaction);

            return new JsonResult(new { Reaction = reaction });
        }
    }
}
