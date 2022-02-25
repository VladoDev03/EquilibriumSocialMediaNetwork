using Data.Entities;
using Data.ViewModels;
using Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Mappers
{
    public static class PostServiceModelMapper
    {
        public static PostServiceModel ToPostServiceModel(this Post post)
        {
            PostServiceModel result = new PostServiceModel()
            {
                Comments = post.Comments.Select(x => x.ToCommentServiceModel()).ToList(),
                Content = post.Content,
                Image = post.Image,
                Id = post.Id,
                User = post.User,
                UserId = post.UserId,
                Reactions = post.Reactions.Select(x => x.ToReactionServiceModel()).ToList()
            };

            return result;
        }

        public static Post ToPost(this PostServiceModel post)
        {
            Post result = new Post()
            {
                Comments = post.Comments.Select(x => x.ToComment()).ToList(),
                Content = post.Content,
                Image = post.Image,
                Id = post.Id,
                UserId = post.UserId,
                User = post.User,
                Reactions = post.Reactions.Select(x => x.ToReaction()).ToList()
            };

            return result;
        }

        public static PostViewModel ToPostViewModel(this PostServiceModel post)
        {
            PostViewModel result = new PostViewModel()
            {
                Id = post.Id,
                Comments = post.Comments.Select(x => x.ToCommentView()).ToList(),
                Content = post.Content,
                Image = post.Image,
                UserId = post.UserId,
                User = post.User.ToUserViewModel()
            };

            return result;
        }
    }
}
