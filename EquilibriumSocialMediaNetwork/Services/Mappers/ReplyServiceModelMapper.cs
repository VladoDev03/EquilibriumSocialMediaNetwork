using Data.Entities;
using Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Mappers
{
    public static class ReplyServiceModelMapper
    {
        public static ReplyServiceModel ToReplyServiceModel(this Reply reply)
        {
            ReplyServiceModel result = new ReplyServiceModel()
            {
                Comment = reply.Comment.ToCommentServiceModel(),
                CommentId = reply.CommentId,
                Content = reply.Content,
                User = reply.User,
                UserId = reply.UserId
            };

            return result;
        }

        public static Reply ToReplyServiceModel(this ReplyServiceModel reply)
        {
            Reply result = new Reply()
            {
                Comment = reply.Comment.ToComment(),
                CommentId = reply.CommentId,
                Content = reply.Content,
                User = reply.User,
                UserId = reply.UserId
            };

            return result;
        }
    }
}
