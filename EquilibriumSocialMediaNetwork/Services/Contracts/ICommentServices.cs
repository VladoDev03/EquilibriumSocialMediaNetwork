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
        CommentServiceModel AddComment(PostServiceModel post, CommentServiceModel comment);

        CommentServiceModel UpdateComment(CommentServiceModel updatedComment);

        void DeleteComment(string id);
    }
}
