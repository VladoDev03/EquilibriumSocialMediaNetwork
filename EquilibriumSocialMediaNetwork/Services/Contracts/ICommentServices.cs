using Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Contracts
{
    public interface ICommentServices
    {
        /// <summary>
        /// Gets all comments stored in the database.
        /// </summary>
        /// <returns>All comments in the database.</returns>
        List<CommentServiceModel> GetAllComments();

        /// <summary>
        /// Gets all comments of the give user.
        /// </summary>
        /// <param name="userId">The id of the user.</param>
        /// <returns>User's comments.</returns>
        List<CommentServiceModel> GetUserComments(string userId);

        /// <summary>
        /// Adds comment to post.
        /// </summary>
        /// <param name="post">The post, the comment will be added to.</param>
        /// <param name="comment">The comments that we are going to add.</param>
        /// <returns>The added comment.</returns>
        CommentServiceModel AddComment(PostServiceModel post, CommentServiceModel comment);

        /// <summary>
        /// Updates comment.
        /// </summary>
        /// <param name="updatedComment">The new data of the comment.</param>
        /// <returns>The new comment.</returns>
        CommentServiceModel UpdateComment(CommentServiceModel updatedComment);

        /// <summary>
        /// Removes the given comment from the database.
        /// </summary>
        /// <param name="id">Id of the comment.</param>
        void DeleteComment(string id);

        /// <summary>
        /// Removes all user's comments from database.
        /// </summary>
        /// <param name="id">Id of the user.</param>
        void DeleteUserComments(string id);
    }
}
