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
        List<PostServiceModel> GetAllPosts();

        List<PostServiceModel> GetPostsForUser(string userId);

        List<CommentServiceModel> GetPostComments(PostServiceModel post);

        List<ReactionServiceModel> GetPostReactions(PostServiceModel post);

        PostServiceModel AddPost(PostServiceModel post);

        PostServiceModel GetPostById(string id);

        List<PostServiceModel> GetUserPosts(string userId);

        PostServiceModel UpdatePost(PostServiceModel updatedPost);

        PostViewModel SetReactionsCount(PostViewModel post);

        /// <summary>
        /// Returns true if post is reacted by user with the given reaction.
        /// Reactions are likely to be: "like" and "dislike".
        /// </summary>
        /// <param name="postId">Searched post's id</param>
        /// <param name="userId">Searched user's id</param>
        /// <param name="reactionName">Name of reaction</param>
        /// <returns></returns>
        bool IsReactedByUser(string postId, string userId, string reactionName);

        void DeletePost(string id);

        void DeleteUserPosts(string userId);

        void DeletePostComments(string id);
    }
}
