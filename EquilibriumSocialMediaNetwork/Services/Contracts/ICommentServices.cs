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
        List<CommentServiceModel> GetAllComments(string userId);

        List<CommentServiceModel> GetUserComments(string userId);

        CommentServiceModel AddComment(PostServiceModel post, CommentServiceModel comment);

        CommentServiceModel UpdateComment(CommentServiceModel updatedComment);

        void DeleteComment(string id);

        void DeleteUserComments(string id);
    }
}
