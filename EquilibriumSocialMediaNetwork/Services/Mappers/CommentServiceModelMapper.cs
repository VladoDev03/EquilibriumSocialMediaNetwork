using Data.Entities;
using Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Mappers
{
    public static class CommentServiceModelMapper
    {
        public static CommentServiceModel ToCommentServiceModel(this Comment comment)
        {
            CommentServiceModel result = new CommentServiceModel()
            {
                Content = comment.Content,
                PostId = comment.PostId,
                Post = comment.Post.ToPostServiceModel(),
                UserId = comment.UserId,
                User = comment.User,
                Replies = comment.Replies.Select(x => x.ToReplyServiceModel()).ToList()
            };

            return result;
        }

        public static Comment ToComment(this CommentServiceModel comment)
        {
            Comment result = new Comment()
            {
                Content = comment.Content,
                PostId = comment.PostId,
                Post = comment.Post.ToPost(),
                UserId = comment.UserId,
                User = comment.User,
                Replies = comment.Replies.Select(x => x.ToReplyServiceModel()).ToList()
            };

            return result;
        }
    }
}
