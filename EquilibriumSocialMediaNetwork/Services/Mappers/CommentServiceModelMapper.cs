using Data.Entities;
using Data.ViewModels;
using Data.ViewModels.Comment;
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
                Id = comment.Id,
                Content = comment.Content,
                TimeCommented = comment.TimeCommented,
                PostId = comment.PostId,
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
                Id = comment.Id,
                Content = comment.Content,
                TimeCommented = comment.TimeCommented,
                PostId = comment.PostId,
                UserId = comment.UserId,
                User = comment.User,
                Replies = comment.Replies.Select(x => x.ToReplyServiceModel()).ToList()
            };

            return result;
        }

        public static CommentViewModel ToCommentView(this CommentServiceModel comment)
        {
            CommentViewModel result = new CommentViewModel()
            {
                Id = comment.Id,
                Content = comment.Content,
                TimeCommented = $"On {comment.TimeCommented.Day}-{comment.TimeCommented.Month}-{comment.TimeCommented.Year} at {comment.TimeCommented.Hour}:{comment.TimeCommented.Minute}",
                UserId = comment.UserId,
                User = comment.User
            };

            return result;
        }
    }
}
