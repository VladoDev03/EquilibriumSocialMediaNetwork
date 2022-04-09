using Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Contracts
{
    public interface IReactionServices
    {
        /// <summary>
        /// Adds the given reaction to the database.
        /// </summary>
        /// <param name="reaction">The reaction to be added.</param>
        /// <returns>The added reaction.</returns>
        ReactionServiceModel AddReaction(ReactionServiceModel reaction);

        /// <summary>
        /// Gets all reactions of a given post.
        /// </summary>
        /// <param name="postId">Id of the post.</param>
        /// <returns>All reactions on the post.</returns>
        List<ReactionServiceModel> GetPostReactions(string postId);

        /// <summary>
        /// Removes all reactions of a given user.
        /// </summary>
        /// <param name="userId">The user's id.</param>
        void DeleteUserReactions(string userId);

        /// <summary>
        /// Removes all reactions on a given post.
        /// </summary>
        /// <param name="postId">Post's id.</param>
        void DeletePostReactions(string postId);
    }
}
