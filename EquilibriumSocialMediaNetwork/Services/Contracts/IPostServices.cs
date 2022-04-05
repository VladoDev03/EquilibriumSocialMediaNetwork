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

        void DeletePost(string id);

        void DeleteUserPosts(string userId);

        void DeletePostComments(string id);
    }
}
