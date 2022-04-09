using Data.ViewModels.Post;
using Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Contracts
{
    public interface IPostServices
    {
        /// <summary>
        /// Gets all posts from the database.
        /// </summary>
        /// <returns>All the posts from the database.</returns>
        List<PostServiceModel> GetAllPosts();

        /// <summary>
        /// Gets the posts that the given user hasn't reacted on and hasn't commented on.
        /// </summary>
        /// <param name="userId">Id of the user.</param>
        /// <returns>Posts that the user hasn't seen.</returns>
        List<PostServiceModel> GetPostsForUser(string userId);

        /// <summary>
        /// Gets all comments of the given post.
        /// </summary>
        /// <param name="post">The post which comments are being searched.</param>
        /// <returns>All the comments on the given post.</returns>
        List<CommentServiceModel> GetPostComments(PostServiceModel post);

        /// <summary>
        /// Gets all reactions of the given post.
        /// </summary>
        /// <param name="post">The post which reactions are being searched.</param>
        /// <returns>All the reactions on the given post.</returns>
        List<ReactionServiceModel> GetPostReactions(PostServiceModel post);

        /// <summary>
        /// Adds post to the database.
        /// </summary>
        /// <param name="post">The post to be added.</param>
        /// <returns>The added post.</returns>
        PostServiceModel AddPost(PostServiceModel post);

        /// <summary>
        /// Gets the post by its id.
        /// </summary>
        /// <param name="id">Id of the post.</param>
        /// <returns>The searched post if it exists.</returns>
        PostServiceModel GetPostById(string id);

        /// <summary>
        /// Gets all posts published by the given user.
        /// </summary>
        /// <param name="userId">The publisher's id.</param>
        /// <returns>All user's posts.</returns>
        List<PostServiceModel> GetUserPosts(string userId);

        /// <summary>
        /// Updates the given post in the database.
        /// </summary>
        /// <param name="updatedPost">The new data of the post.</param>
        /// <returns>The updated post.</returns>
        PostServiceModel UpdatePost(PostServiceModel updatedPost);

        /// <summary>
        /// Sets likes count and dislikes count on the given post.
        /// </summary>
        /// <param name="post">The post whose likes and dislikes are searched.</param>
        /// <returns>The updated post.</returns>
        PostViewModel SetReactionsCount(PostViewModel post);

        /// <summary>
        /// Finds the comments count of the given post.
        /// </summary>
        /// <param name="post">The posts which comments' count is searched.</param>
        /// <returns>The updated post.</returns>
        PostViewModel SetCommentsCount(PostViewModel post);

        /// <summary>
        /// Returns true if post is reacted by user with the given reaction.
        /// Reactions are likely to be: "like" and "dislike".
        /// </summary>
        /// <param name="postId">Searched post's id</param>
        /// <param name="userId">Searched user's id</param>
        /// <param name="reactionName">Name of reaction</param>
        /// <returns></returns>
        bool IsReactedByUser(string postId, string userId, string reactionName);

        /// <summary>
        /// Removes post from the database.
        /// </summary>
        /// <param name="id">Id of the post that is deleted.</param>
        void DeletePost(string id);

        /// <summary>
        /// Removes all posts of the given user.
        /// </summary>
        /// <param name="userId">Id of the user.</param>
        void DeleteUserPosts(string userId);

        /// <summary>
        /// Deletes all comments on the given post.
        /// </summary>
        /// <param name="id">Post's id.</param>
        void DeletePostComments(string id);
    }
}
